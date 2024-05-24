using Medipol_Hospital.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MediSoft.Entities
{
    public class Appointment 
    {
        [Key]
        public int meet_ID { get; set; }
        public int p_ID { get; set; }
        public int doctorID { get; set; }
        public DateTime appinmentTime { get; set; }

       
    }
}