using Medipol_Hospital.Abstract;
using Medipol_Hospital.Adapter;
using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System.Linq;
using System.Windows.Forms;

namespace Medipol_Hospital.Concrete
{
    public class LoginManager : ILoginService
    {
        Context c = new Context();
        ICheckedService check = new MernisCheckOfPerson(); //doğrulama hizmeti seç fake ya da Mernis ilerde farklı bir doğrulama hizmeti de gelebilirr

        public bool Logins(string tcno, string password)
        {
            if (tcno == "11111111111" && password == "***")  //Müdür girişi
            {
                Form3 form3 = new Form3(); //en yetkili sayfaya erişim
                form3.Show();
                return true;  //onayla
            }
            else
            {
                string hashpass = Sha256Converter.ComputeSha256Hash(password); //gelen değeri **Hashle**

                Doctors dc = c.Doctors.FirstOrDefault(x => x.nationalityNo.ToString() == tcno && x.Password == hashpass); //kontrol et

                Patinets hasta = c.Patches.FirstOrDefault(x => x.nationalityNo.ToString() == tcno && x.Password == hashpass); //kontrol et


                if (dc != null) //bir değer gelir ise
                {
                    Session.sessionId = dc.doctorID;  //oturum aç
                    Session.UserName = dc.Name;
                    Session.UserSurname = dc.Surname;
                    Session.Password = dc.Password;
                    Session.WhoIsLoggedIn = 1; //1= doktor oturumu
                    Form5 form5 = new Form5();
                    form5.Show();

                    return true;
                }
                else if (hasta != null)
                {

                    Session.sessionId = hasta.pID;
                    Session.UserName = hasta.Name;
                    Session.UserSurname = hasta.Surname;
                    Session.Password = hasta.Password;
                    Session.WhoIsLoggedIn = 0; // 0 = hasta oturumu
                    Form4 form4 = new Form4();
                    form4.Show();
                    return true;
                }
                else
                {
                    MessageBox.Show("Bulunamadı");
                    return false;
                }

            }
        }
        public bool RegisterDoctor(Doctors doctor)   //doktor kayıt etme methodu
        {
            if (!c.Patches.Any(a => a.nationalityNo == doctor.nationalityNo))   //daha önce kayıt olmuş mu?
            {
                //böyle biri gerçekten var mı?

                if (check.CheckofPerson(doctor)) //kişi doğrulama hizmeti 
                {
                    c.Doctors.Add(doctor);//ekle tabloya
                    c.SaveChanges();    //kaydet
                    MessageBox.Show("Doktor başarıyla eklendi."); //feedback
                    Form5 form5 = new Form5();
                    form5.Show();  //yönlendir
                    return true;
                }
                else
                {
                    MessageBox.Show("Mernis Veritabanında Kişi Bulunamadı");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Zaten Kayıtlı Giriş Ekranına Gidiniz");
                return false;
            }
        }

        public bool RegisterPatient(Patinets patinet)
        {

            if (!c.Patches.Any(a => a.nationalityNo == patinet.nationalityNo))
            {
                if (check.CheckofPerson(patinet)) //kişi doğrulanınca if'in içine gir
                {
                    c.Patches.Add(patinet); //ekle tabloya
                    c.SaveChanges();    //kaydet
                    MessageBox.Show("Hasta başarıyla eklendi."); //feedback
                    Session.sessionId = patinet.pID;
                    Session.UserName = patinet.Name;

                    Form4 form4 = new Form4();
                    form4.Show();  //yönlendir
                    return true;
                }
                else
                {
                    MessageBox.Show("Mernis Veritabanında Kişi Bulunamadı");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Zaten Kayıtlı Giriş Ekranına Gidiniz");
                return false;
            }
        }

        public bool Verification(string mail, int random)                //kişiyi mail ile doğrulama hizmeti
        {
            Doctors dc = c.Doctors.FirstOrDefault(x => x.Email.ToString() == mail);     //bu mailde biri var mı
            Patinets hasta = c.Patches.FirstOrDefault(x => x.Email.ToString() == mail);


            if (dc != null)
            {
                MailService.MailService.SendEmail(dc.Email,"E-Posta Onay Kodu",$"Medipol Hastanesi Onay KOdunuz :{random}");
                Session.WhoIsLoggedIn = 1;        //kısmi oturum aç ama erişim verme
                Session.sessionId = dc.doctorID;
                return true;
            }
            else if (hasta != null)
            {
                MailService.MailService.SendEmail(hasta.Email, "E-Posta Onay Kodu", $"Medipol Hastanesi Onay KOdunuz :{random}");
                Session.WhoIsLoggedIn = 0;
                Session.sessionId = hasta.pID;
                return true;
            }
            else
            {
                MessageBox.Show("E-Posta Bulunamadı :(");
                return false;
            }
        }
    }
}
