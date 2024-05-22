using Medipol_Hospital.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MediSoft.Entities;

namespace Medipol_Hospital.Concrete
{
    public class PatientManager : IPatientService
    {
        Context c = new Context();
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
