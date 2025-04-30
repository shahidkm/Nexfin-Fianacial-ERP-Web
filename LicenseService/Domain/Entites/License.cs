using System.ComponentModel.DataAnnotations;

namespace LicenseService.Domain.Entites
{
    public class LicenseModel
    {
        [Key]
        public Guid LicenseId { get; set; }
        public string LicenseType { get; set; } = "User";
        public string UserId { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }
        public string? VerificationCode { get; set; }
        public string PublicKey { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt = DateTime.Now;

        public string LicenseKey { get; set; }
      
    }
}
