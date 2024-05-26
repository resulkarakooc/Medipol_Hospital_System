using Medipol_Hospital.Abstract;
using Medipol_Hospital.Adapter;
using Medipol_Hospital.Entities;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medipol_Hospital.Concrete
{
    public class LoginManager : ILoginService
    {
        Context c = new Context();
        ICheckedService check = new FakeAdapterCheckOfPerson(); //doğrulama hizmeti seç
        public bool Login(Patinets hasta, Doctors dc)
        {
            if (dc != null)
            {
                Session.sessionId = dc.doctorID;
                Session.UserName = dc.Name;
                Form5 form5 = new Form5();
                form5.Show();

                return true;
            }
            else if (hasta != null)
            {

                Session.sessionId = hasta.pID;
                Session.UserName = hasta.Name;
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
    }
}
