
using LicenseService.Contracts.DTOs;
using LicenseService.Application.Interfaces;
using MediatR;
using LicenseService.Domain.Entites;
using LicenseService.Infrastucture.Services;

namespace LicenseService.Application.Features.Commands
{
    public class LicenseCommandHandler : IRequestHandler<LicenseCommand, string>
    {
   
        private readonly ILicenseRepository _licenseRepository;
        private readonly OtpService _otpSevice;
        public LicenseCommandHandler( ILicenseRepository licenseRepository ,OtpService otpService)
        {
            
            _licenseRepository = licenseRepository;
            _otpSevice = otpService;
        }

        public async Task<string> Handle(LicenseCommand request, CancellationToken cancellationToken)
        {

            

            var license = new LicenseDto
            {
                Fullname = request.Fullname,
                UserId = request.UserId,
                Address = request.Address,
                Country = request.Country,
                State = request.State,
                District = request.District,
                Pincode = request.Pincode,
                Email = request.Email,

            };

          var result = await _licenseRepository.GenerateLicenseKey(license);
            return result;
        }
    }
}
