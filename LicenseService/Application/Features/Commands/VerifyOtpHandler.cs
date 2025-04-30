
using LicenseService.Contracts.DTOs;
using LicenseService.Application.Interfaces;
using MediatR;
using LicenseService.Domain.Entites;
using LicenseService.Infrastucture.Services;

namespace LicenseService.Application.Features.Commands
{
    public class VerifyOtpHandler : IRequestHandler<VerifyOtpCommand, bool>
    {


        private readonly OtpService _otpSevice;
        public VerifyOtpHandler(OtpService otpService)
        {


            _otpSevice = otpService;
        }

        public async Task<bool> Handle(VerifyOtpCommand command, CancellationToken cancellationToken)
        {

            var response = await _otpSevice.VerifyOtpAsync(command.Email,command.Otp);

            return response;

        }
    }
}
