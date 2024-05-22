using Medipol_Hospital.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediSoft.Entities
{
    public class Peak
    {
        [Key]
        public int peakID { get; set; }
        public int MyProperty { get; set; }
        public int p_ID { get; set; }
        public int doctorID { get; set; }
        public string Description { get; set; }
    }
}