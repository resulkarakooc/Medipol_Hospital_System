using Medipol_Hospital.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediSoft.Entities
{
    public class Doctors : User
    {
        [Key]
        public int doctorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long nationalityNo { get; set; }
        public int BirthYear { get; set; }
        public string Password { get; set; }


        public string FullName
        {
            get { return $"{Name} {Surname}"; }
        }


    }
}