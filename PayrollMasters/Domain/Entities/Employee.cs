using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int GroupId { get; set; }

        //public string Code { get; set; }
        public string FullName { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfJoining { get; set; } = DateTime.Now;

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string? BankName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? IFSC { get; set; }

        public decimal BasicSalary { get; set; }

        // Navigation
        //public Company Company { get; set; }
        public EmployeeGroup Group { get; set; }
        public ICollection<EmployeeAttendance> Attendances { get; set; }
        public ICollection<EmployeePayHeadAssignment> PayHeadAssignments { get; set; }
    }

}
