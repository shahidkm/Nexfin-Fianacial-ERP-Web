namespace UserService.Domain.Entities
{
    public class User
    {

        public Guid UserId { get; set; }
        public string Fullname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Role { get; set; } = "User";
        //public string LicenseKey { get; set; }
        //public string LicenseStatus { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;


    }
}
