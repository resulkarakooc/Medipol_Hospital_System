using MediSoft.Entities;

namespace Medipol_Hospital.Abstract
{
    public interface ICheckedService
    {
        bool CheckofPerson(Doctors doctor);
        bool CheckofPerson(Patinets patinet);
        
    }
}
