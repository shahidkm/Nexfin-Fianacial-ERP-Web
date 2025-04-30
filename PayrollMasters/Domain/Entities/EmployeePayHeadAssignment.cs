using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class EmployeePayHeadAssignment
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PayHeadId { get; set; }

        public decimal Amount { get; set; } // fixed or percentage
        public bool ?IsPercentage { get; set; }

        //public DateTime EffectiveDate { get; set; }
        //public DateTime? EndDate { get; set; }

        public Employee Employee { get; set; }
        public PayHead PayHead { get; set; }
    }

}
