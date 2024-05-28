using System;
using System.ComponentModel.DataAnnotations;

namespace MediSoft.Entities
{
    public class Patinets 
    {
        [Key]
        public int pID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string nationalityNo { get; set; }
        public int BirthYear { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime registerDate { get; set; }
        public int? doctorID { get; set; }
        


    }
}