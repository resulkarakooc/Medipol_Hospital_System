using Medipol_Hospital.Abstract;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace Medipol_Hospital.Concrete
{
    public class DoctorManager : IDoctorService
    {
        Context c = new Context();
        public List<object> GetMyPat(int id)
        {
            // LINQ sorgusu yap inner join için
            var sonuc = (from doctor in c.Doctors                   // Doktorlar tablosundaki her bir satır için
                         join app in c.Appointments                // Randevular için de aynısı
                         on doctor.doctorID equals app.doctorID   // doctorID aynı olan satırları tutmak için
                         join pat in c.Patches                   // Aynısı hasta tablosu için
                         on app.p_ID equals pat.pID             // Randevu tablosu hasta ID ile eşle ve tut
                         where doctor.doctorID == id           // Gelen parametreden doktoru ayıkla
                         select new
                         {
                             ID = pat.pID,  // Yeni obje satırları eşleme
                             PatientName = pat.Name + " " + pat.Surname,
                             Dogum_Yılı = pat.BirthYear,
                             DoctorName = doctor.Name + " " + doctor.Surname
                         })
                         .GroupBy(p => p.ID)                      // Hasta ID'sine göre gruplandır
                         .Select(g => g.FirstOrDefault())        // Her gruptan ilk kaydı seç
                         .ToList<object>();                     // Objeleri listelere ata

            return sonuc; // Gönder
        }


        public void SendMail(int id, string konu, string meesage)
        {
            Patinets patinet = c.Patches.FirstOrDefault(x=>x.pID == id);
            string mail = patinet.Email;

            MailService.MailService.SendEmail(mail,konu, meesage);
            MessageBox.Show($"{patinet.Name} {patinet.Surname} isimli hastaya mail gönderildi.");
        }



        public void PrescriptionsCreate(int id,string ilaç,string tani,string aciklama)
        {
            var sonuc = c.Patches.FirstOrDefault(x => x.pID == id);  //hastayı bul
            string ad = sonuc.Name; 
            string soyad = sonuc.Surname;
            string birth = sonuc.BirthYear.ToString();

            PdfCreater.Create(sonuc.nationalityNo, ad, soyad, Session.UserName,
                Session.UserSurname, DateTime.Now.ToString(), ilaç, tani, aciklama);  //reçete oluştur
        }
    }
}
