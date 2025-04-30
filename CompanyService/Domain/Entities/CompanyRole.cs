using System.ComponentModel.DataAnnotations;

namespace CompanyService.Domain.Entities
{
    public class CompanyRole
    {
        [Key]
        public Guid Id { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
   
        public Company Company { get; set; }
    }
}
