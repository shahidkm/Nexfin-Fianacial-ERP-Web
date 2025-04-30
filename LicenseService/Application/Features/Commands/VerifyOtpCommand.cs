using MediatR;

namespace LicenseService.Application.Features.Commands
{
    public record VerifyOtpCommand(string Email,string Otp):IRequest<bool>;
}
