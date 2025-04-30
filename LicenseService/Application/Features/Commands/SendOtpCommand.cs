using MediatR;

namespace LicenseService.Application.Features.Commands
{
   public record SendOtpCommand(string Email):IRequest<string>;
}
