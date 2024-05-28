using Medipol_Hospital.Abstract;
using Medipol_Hospital.Adapter;
using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Medipol_Hospital.Concrete
{
    public class LoginManager : ILoginService
    {
        Context c = new Context();
        ICheckedService check = new MernisCheckOfPerson(); //doğrulama hizmeti seç


        public bool Logins(string tcno, string password)
        {
            if (tcno == "***" && password == "***")
            {
                Form3 form3 = new Form3();
                form3.Show();
                return true;
            }
            else
            {
                string hashpass = Sha256Converter.ComputeSha256Hash(password);

                Doctors dc = c.Doctors.FirstOrDefault(x => x.nationalityNo.ToString() == tcno && x.Password == hashpass);

                Patinets hasta = c.Patches.FirstOrDefault(x => x.nationalityNo.ToString() == tcno && x.Password == hashpass);


                if (dc != null)
                {
                    Session.sessionId = dc.doctorID;
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



        public bool RegisterDoctor(Doctors doctor)
        {
            if (!c.Patches.Any(a => a.nationalityNo == doctor.nationalityNo))
            {
                //böyle biri gerçekten var mı?

                if (check.CheckofPerson(doctor)) //kişi doğrulanınca if'in içine gir
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

        public bool Verification(string mail, int random)
        {


            Doctors dc = c.Doctors.FirstOrDefault(x => x.Email.ToString() == mail);
            Patinets hasta = c.Patches.FirstOrDefault(x => x.Email.ToString() == mail);


            if (dc != null)
            {
                MailService.MailService.SendEmail(dc.Email, random);
                Session.WhoIsLoggedIn = 1;
                Session.sessionId = dc.doctorID;
                return true;
            }
            else if (hasta != null)
            {
                MailService.MailService.SendEmail(hasta.Email, random);
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
