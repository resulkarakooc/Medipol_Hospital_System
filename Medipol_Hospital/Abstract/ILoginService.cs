using Medipol_Hospital.Entities;
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
        bool Login(Patinets hasta, Doctors dc);

        bool RegisterPatient(Patinets patinet);
        bool RegisterDoctor(Doctors doctor);
    }
}
