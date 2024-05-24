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
        public List<Patinets> GetPatAll()
        {
            Context ce = new Context();
            return ce.Patches.ToList();
        }

        public List<Doctors> GetDoctorAll()
        {
            

            return c.Doctors.ToList();
        }

        public void RemoveDoctor(Doctors doctor)
        {
            
            DialogResult result = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int a = doctor.doctorID;
                var deger = c.Doctors.FirstOrDefault(x => x.doctorID == a);
                c.Doctors.Remove(deger);
                c.SaveChanges();
            }
        }

        public void RemoveAppointment(Appointment app)
        {
            c.Appointments.Remove(app);
            c.SaveChanges();
        }

        public List<object> GetAllPat()
        {
            //LINQ sorgusu yap inner join için
            var sonuc = (from doctor in c.Doctors                              //dokotorlar tablosundaki her bir satır içi ism ata
                         join app in c.Appointments                            //randevular içi ne aynısı
                         on doctor.doctorID equals app.doctorID                //doctor ID aynı olan satırları tut
                         join pat in c.Patches                                 //aynısı hasta tablosu için
                         on app.p_ID equals pat.pID                            //randevu tablosu hasta ıd ile eşle ve tut
                                                 // gelen parametreden doktoru ayıkla
                         select new
                         {
                             DoctorName = doctor.Name + " " + doctor.Surname,  //yeni obje satırları eşleme
                             PatientName = pat.Name + " " + pat.Surname,
                             Randevu_Tarihi = app.appinmentTime

                         }).ToList<object>();                                  //objeleri listelere ata

            return sonuc; //gönder
        }
    }
}
