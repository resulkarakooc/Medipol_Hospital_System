using System;
using System.Collections.Generic;

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
