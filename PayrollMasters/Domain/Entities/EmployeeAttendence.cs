using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class EmployeeAttendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public int AttendanceTypeId { get; set; }
        public DateTime Date { get; set; }

        public Employee Employee { get; set; }
        public AttendanceType AttendanceType { get; set; }
    }

}
