using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Contracts.DTOs.UserDTOs;
using UserService.Domain.Entities;
using UserService.Infrastructure.Persistence.Repositories;

namespace UserService.Application.Features.Commands
{

    public class LoginUserHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LoginUserHandler> _logger;

        public LoginUserHandler(IUserRepository userRepository, IMapper mapper,ILogger<LoginUserHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LoginResponse> Handle(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            try
            {
                var verify = await _userRepository.VerifyUser(loginCommand.Email);

                if (verify == null)
                {
                    _logger.LogError("User not found.");
                    return new LoginResponse { Message = "User not found." };
                }
                if (verify.Email!=loginCommand.Email)
                {
                    _logger.LogError("Email not matches.");
                    return new LoginResponse { Message = "Email not matches." };
                }
                if (verify.Password != loginCommand.Password)
                {
                    _logger.LogError("Incorrect password.");
                    return new LoginResponse { Message = "Incorrect password." };
                }

                var response = await _userRepository.LoginUser(verify);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new LoginResponse { Message = ex.Message };
            }
        }
    }
}
