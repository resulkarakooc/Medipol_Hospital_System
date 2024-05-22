using Medipol_Hospital.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediSoft.Entities
{
    public class Patinets : User
    {
        [Key]
        public int pID { get; set; }
        public string nationalityNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime registerDate { get; set; }
        public int birthYear { get; set; }

        public int doctorID { get; set; }


    }
}