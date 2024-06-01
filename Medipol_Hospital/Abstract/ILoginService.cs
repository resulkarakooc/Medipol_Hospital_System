

using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medipol_Hospital.Abstract
{
    public interface ILoginService
    {
        bool Logins(string tcno,string password);
        bool RegisterPatient(Patinets patinet);
        bool RegisterDoctor(Doctors doctor);
        bool Verification(string mail, int random);
    }
}
