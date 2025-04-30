using MediatR;

namespace PayrollService.Application.Features.Commands
{
    public record AttendenceTypeCommand(string AttendenceName, string Type, string Unit) : IRequest<string>;
}
