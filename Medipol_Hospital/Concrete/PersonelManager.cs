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
      

        public List<object> GetDoctorAll()
        {

            var doctors = c.Doctors
                .Select(d => new
                {
                    d.doctorID,
                    d.nationalityNo,
                    d.Name,
                    d.Surname,
                    d.BirthYear
                })
                .ToList<object>();

            return doctors;
        }

        public void RemoveDoctor(int id)
        {

            DialogResult result = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var deger = c.Doctors.FirstOrDefault(x => x.doctorID == id);
                c.Doctors.Remove(deger);
                c.SaveChanges();
            }
        }



        public List<object> GetAllPat()
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

        public void RemoveAppointment(int id)
        {
            var sonuc = c.Appointments.FirstOrDefault(x => x.meet_ID == id);
            c.Appointments.Remove(sonuc);
            MessageBox.Show($"{sonuc.meet_ID}'li randevu silindi ");

            c.SaveChanges();
        }

        public List<Object> GetAllAppointment()
        {
            var sonuc = (from rnd in c.Appointments
                         join hasta in c.Patches
                         on rnd.p_ID equals hasta.pID
                         join doctor in c.Doctors
                         on rnd.doctorID equals doctor.doctorID
                         select new
                         {
                             Randevu_ID = rnd.meet_ID,
                             Doktor_Ismi = doctor.Name + " " + doctor.Surname,
                             Hasta_İsmi = hasta.Name + " " + hasta.Surname,
                             Randevu_Tarihi = rnd.appinmentTime

                         }).ToList<object>();

            return sonuc; //gönder
        }

    }
}
