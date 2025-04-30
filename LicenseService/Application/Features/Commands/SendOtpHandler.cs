
using LicenseService.Contracts.DTOs;
using LicenseService.Application.Interfaces;
using MediatR;
using LicenseService.Domain.Entites;
using LicenseService.Infrastucture.Services;

namespace LicenseService.Application.Features.Commands
{
    public class SendOtpHandler : IRequestHandler<SendOtpCommand, string>
    {
        private readonly OtpService _otpSevice;
        public SendOtpHandler( OtpService otpService)
        {
         _otpSevice = otpService;
        }
        public async Task<string> Handle(SendOtpCommand command, CancellationToken cancellationToken)
        {

            var response = await _otpSevice.SendOtp(command.Email);

            return response;

        }
    }
}
