using MediatR;
using UserService.Contracts.DTOs.UserDTOs;

namespace UserService.Application.Features.Commands
{
    public record RegisterUserCommand(string FullName, string Email, string Password) : IRequest<string>;


}
