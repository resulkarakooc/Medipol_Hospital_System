using Medipol_Hospital.Abstract;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medipol_Hospital.Concrete
{

    public class PersonelManager : IPersoneLService 
    {
        Context c = new Context();
        public List<object> GetDoctorAll()  //doktorları getrime methodu
        {
            var doctors = c.Doctors
                .Select(d => new    //  seçili bir obje oluştur
                {
                    d.doctorID,       
                    d.nationalityNo,
                    d.Name,
                    d.Surname,
                    d.BirthYear
                })
                .ToList<object>();  //Listeye dönüştür

            return doctors;
        }

        public void RemoveDoctor(int id) //İşten kov doktoru
        {
            DialogResult result = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //ama öncesinde sor 
            if (result == DialogResult.Yes) //onay gelir ise
            {
                var deger = c.Doctors.FirstOrDefault(x => x.doctorID == id); //o id'li doktoru bul
                c.Doctors.Remove(deger);  //sil 
                c.SaveChanges(); //kaydet
            }
        }

        public List<object> GetAllPat()  //hasta listesi
        {
            var hasta = c.Patches.Select(d => new
            {
                d.pID,
                d.nationalityNo,
                d.Name,
                d.Surname,
                d.Email,
                d.BirthYear
            }).ToList<Object>();

            return hasta; //gönder
        }

        public void RemoveAppointment(int id) //randevu sil
        {
            var sonuc = c.Appointments.FirstOrDefault(x => x.meet_ID == id); //bul randevuyu
            c.Appointments.Remove(sonuc); //sil
            c.SaveChanges(); //kaydet

            MessageBox.Show($"{sonuc.meet_ID} ID'li randevu silindi ");

            
        }
        public List<Object> GetAllAppointment()  //tüm randevuları getir
        {
            var sonuc = (from rnd in c.Appointments  //inner join üç tabloda LINQ kullanarak
                         join hasta in c.Patches
                         on rnd.p_ID equals hasta.pID
                         join doctor in c.Doctors
                         on rnd.doctorID equals doctor.doctorID
                         select new
                         {
                             Randevu_ID = rnd.meet_ID,
                             Doktor_Ismi = doctor.Name + " " + doctor.Surname,
                             Hasta_İsmi = hasta.Name + " " + hasta.Surname,
                             Randevu_Tarihi = rnd.appinmentTime,
                             saati = rnd.hourAndSecond

                         }).ToList<object>(); 

            return sonuc; //gönder
        }

    }
}
