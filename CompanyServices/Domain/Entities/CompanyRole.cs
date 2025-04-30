using System.ComponentModel.DataAnnotations;

namespace CompanyServices.Domain.Entities
{
    public class CompanyRole
    {
        [Key]
        public Guid Id { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public Company Company { get; set; }
    }
}
