using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class AttendanceType
    {
        [Key]
        public int AttendanceTypeId { get; set; }
        public string AttendenceName { get; set; } 
        public string Type { get; set; } 
        public string Unit { get; set; } 
    }

}
