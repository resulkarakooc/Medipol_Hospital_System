using Medipol_Hospital.Abstract;
using Medipol_Hospital.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediSoft.Entities
{
    public class Doctors  
    {
        [Key]
        public int doctorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string nationalityNo { get; set; }
        public int BirthYear { get; set; }
        public string Password { get; set; }



        public string FullName
        {
            get { return $"{Name} {Surname}"; }
        }


    }
}