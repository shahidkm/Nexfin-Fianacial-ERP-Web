using MediatR;
namespace LicenseService.Application.Features.Commands
{
    public class LicenseCommand : IRequest<string>
    {
        public string? UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
            public string State { get; set; }   
        public string District { get; set; }
        public string Pincode { get; set; }



    }
}
