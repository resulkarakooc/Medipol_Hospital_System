using MediSoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medipol_Hospital.Abstract
{
    public interface IPersoneLService
    {
       
        List<object> GetDoctorAll();
        void RemoveDoctor(int id);
        void RemoveAppointment(int id);
        List<object> GetAllPat();

        List<Object> GetAllAppointment();




    }
}
