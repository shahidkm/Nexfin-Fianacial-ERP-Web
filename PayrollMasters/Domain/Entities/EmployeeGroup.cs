using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class EmployeeGroup
    {
        [Key]
        public int GroupId { get; set; }
        public int CompanyId { get; set; }

        public string GroupName { get; set; }

        //public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

}
