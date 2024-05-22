using Medipol_Hospital.Abstract;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medipol_Hospital.Concrete
{
    public class DoctorManager : IDoctorService
    {
        Context c = new Context();
        public List<Patinets> GetMyPat(int id)
        {
            return c.Patches.Where(x=>x.doctorID == id).ToList();   
        }
    }
}
