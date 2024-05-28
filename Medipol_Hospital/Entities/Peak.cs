using System.ComponentModel.DataAnnotations;

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