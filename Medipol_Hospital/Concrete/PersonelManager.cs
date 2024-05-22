using Medipol_Hospital.Abstract;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medipol_Hospital.Concrete
{

    public class PersonelManager : IPersoneLService
    {
        public List<Patinets> GetPatAll()
        {
            Context ce = new Context();
            return ce.Patches.ToList();
        }

        public List<Doctors> GetDoctorAll()
        {
            Context c = new Context();

            return c.Doctors.ToList();
        }
    }
}
