using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class PayHead
    {
        [Key]
        public int PayHeadId { get; set; }
        public string Name { get; set; } // e.g. Basic, HRA
        public string Type { get; set; } // Earnings or Deductions
        public string CalculationType { get; set; } // Fixed, Percentage, AttendanceBased

        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }
        public int? AttendanceTypeId { get; set; }

        public AttendanceType AttendanceType { get; set; }
    }

}
