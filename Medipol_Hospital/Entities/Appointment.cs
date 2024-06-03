using System;
using System.ComponentModel.DataAnnotations;

namespace MediSoft.Entities
{
    public class Appointment 
    {
        [Key]
        public int meet_ID { get; set; }
        public int p_ID { get; set; }
        public int doctorID { get; set; }
        public DateTime appinmentTime { get; set; }
        public string hourAndSecond { get; set; }
    }
}