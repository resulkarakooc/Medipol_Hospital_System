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

        public List<Doctors> GetDoctorAll()
        {
            Context c = new Context();

            return c.Doctors.ToList();
        }
    }
}
