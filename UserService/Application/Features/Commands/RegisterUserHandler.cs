using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Contracts.DTOs.UserDTOs;
using UserService.Domain.Entities;

namespace UserService.Application.Features.Commands
{
    public class RegisterUserHandler :IRequestHandler<RegisterUserCommand,string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegisterUserHandler> _logger;
        public RegisterUserHandler(IUserRepository userRepository,IMapper mapper,ILogger<RegisterUserHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<string> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            try { 
                var email = await _userRepository.VerifyEmail(command.Email);
                if (email==false)
                {
                    _logger.LogError("Already an user registered with this email.");
                    return ("Already an user registered with this email.");
                }
                var user = _mapper.Map<User>(command);
                var response = await _userRepository.RegisterUser(user);
                return response;
           }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return (ex.Message);
            }
            }

      
    }
}
