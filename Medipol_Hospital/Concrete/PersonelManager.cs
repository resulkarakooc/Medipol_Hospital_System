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
            c.Doctors.Remove(doctor);
            DialogResult result = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                c.SaveChanges();
            }
        }
    }
}
