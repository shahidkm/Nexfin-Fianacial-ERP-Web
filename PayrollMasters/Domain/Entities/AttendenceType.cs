using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class AttendanceType
    {
        [Key]
        public int AttendanceTypeId { get; set; }
        public string AttendenceName { get; set; } // e.g. Present, Leave
        public string Type { get; set; } // Attendance or Production
        public string Unit { get; set; } // Days, Hours
    }

}
