using Medipol_Hospital.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MediSoft.Entities;
using System.Windows.Forms;

namespace Medipol_Hospital.Concrete
{
    public class PatientManager : IPatientService
    {
        Context c = new Context();

        public void AddNewAppointment(Appointment app)   //randevu oluştur
        {
            if (!c.Appointments.Any(x => x.appinmentTime == app.appinmentTime && x.doctorID == app.doctorID && x.hourAndSecond == app.hourAndSecond))
            {
                c.Appointments.Add(app);  //ekle
                c.SaveChanges();         //kaydet
            }
            else
            {
                MessageBox.Show("Randevu Dolu");
            }
        }

        public List<Appointment> GetCurrentAppt(int id)       //mevcut randevularımı getir
        {
            return c.Appointments.Where(x=>x.p_ID == id).ToList(); //idler eşit ise getir liste olarak
        }

        public List<Doctors> GetDoctorAll() //doktorların listesi
        {
            return c.Doctors.ToList();
        }
    }
}
