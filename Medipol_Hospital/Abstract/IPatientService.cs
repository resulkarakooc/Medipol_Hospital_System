using MediSoft.Entities;
using System.Collections.Generic;

namespace Medipol_Hospital.Abstract
{
    public interface IPatientService
    {
        List<Doctors> GetDoctorAll();
        List<Appointment> GetCurrentAppt(int id);
        void AddNewAppointment(Appointment app);
    }
}
