using Medipol_Hospital.Abstract;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medipol_Hospital.Adapter
{
    public class FakeAdapterCheckOfPerson : ICheckedService
    {
        public bool CheckofPerson(Doctors doctor)  //developer için geçici 
        {
            return true;
        }

        public bool CheckofPerson(Patinets patinet)
        {
            return true;
        }
    }
}
