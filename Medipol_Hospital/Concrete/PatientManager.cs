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

        public void AddNewAppointment(Appointment app)
        {
            if (!c.Appointments.Any(x => x.appinmentTime == app.appinmentTime && x.doctorID == app.doctorID && x.hourAndSecond == app.hourAndSecond))
            {
                c.Appointments.Add(app);
                c.SaveChanges();
            }
            else
            {
                MessageBox.Show("Randevu Dolu");
            }
        }

        public List<Appointment> GetCurrentAppt(int id)
        {
            return c.Appointments.Where(x=>x.p_ID == id).ToList();
        }

        public List<Doctors> GetDoctorAll()
        {
            return c.Doctors.ToList();
        }
    }
}
