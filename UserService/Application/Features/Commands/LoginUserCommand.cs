using MediatR;
using UserService.Contracts.DTOs.UserDTOs;

namespace UserService.Application.Features.Commands
{
    public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;
}
