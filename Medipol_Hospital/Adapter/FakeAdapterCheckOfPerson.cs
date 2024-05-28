using Medipol_Hospital.Abstract;
using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medipol_Hospital.Adapter
{
    public class FakeAdapterCheckOfPerson : ICheckedService  //developer için geçici 
    {
        public bool CheckofPerson(Doctors doctor)
        {
            return true;
        }

        public bool CheckofPerson(Patinets patinet)
        {
            return true;
        }
    }
}
