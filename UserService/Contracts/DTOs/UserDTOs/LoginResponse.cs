namespace UserService.Contracts.DTOs.UserDTOs
{
    public class LoginResponse
    {
        public string Fullname { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public string Message { get; set; }
    }
}
