using Medipol_Hospital.Abstract;

using Medipol_Hospital.ServiceReference1;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medipol_Hospital.Adapter
{
    public class MernisCheckOfPerson : ICheckedService
    {

        KPSPublicSoapClient isReel = new KPSPublicSoapClient();
        public bool CheckofPerson(Doctors doctor) //Mernis'ten dönen değer true veya false olucak 
        {
            return isReel.TCKimlikNoDogrula(Convert.ToInt64(doctor.nationalityNo), doctor.Name.ToUpper(), doctor.Surname.ToUpper(), doctor.BirthYear);
        }

        public bool CheckofPerson(Patinets patinet)
        {
            return isReel.TCKimlikNoDogrula(Convert.ToInt64(patinet.nationalityNo), patinet.Name.ToUpper(), patinet.Surname.ToUpper(), patinet.BirthYear);
        }
    }
}
