using UserService.Contracts.DTOs.UserDTOs;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces
{
    public interface IUserRepository
    {
       Task<string> RegisterUser(User user);
        Task<LoginResponse> LoginUser(User user);
        Task<bool> VerifyEmail(string email);
        Task<User> VerifyUser(string email);
        Task<User> VerifyUserById(string userId);
        Task<string> AddCompany(User user,int CompanyId);
    }
}
