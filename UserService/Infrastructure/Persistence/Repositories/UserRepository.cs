using UserService.Application.Interfaces;
using UserService.Contracts.DTOs.UserDTOs;
using UserService.Domain.Entities;
using UserService.Infrastructure.Persistence.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Services;
using MassTransit;
using Sprache;
namespace UserService.Infrastructure.Persistence.Repositories
{
    public class UserRepository :IUserRepository
    {

         private readonly IPublishEndpoint _publishEndpoint;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;
        private readonly ILogger<UserRepository> _logger;
        private readonly TokenWithCompany _companyToken;
        public UserRepository(AppDbContext appDbContext,IMapper mapper,JwtService jwtService,ILogger<UserRepository> logger,TokenWithCompany tokenWithCompany)
        {
            _context = appDbContext;
            _mapper = mapper;
            _jwtService = jwtService;
            _logger = logger;
            _companyToken = tokenWithCompany;
        }



        public async Task<string> RegisterUser(User user)
        {
            try {
                if (user.Fullname == null)
                {
                    _logger.LogInformation("Full name is required");
                    return ("Full name is required");
                }
                if (user.Email == null)
                {
                    _logger.LogInformation("Email is required");
                    return ("Email is required");
                }
                if (user.Password == null)
                {
                    _logger.LogInformation("Password is required");
                    return ("Password is required");
                }
                if (user.Password.Length<6)
                {
                    _logger.LogInformation("Password must contain six characteres");
                    return ("Password must contain six characteres");
                }
                await _context.Users.AddAsync(user);
                _context.SaveChanges();
                return ("User Registered");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return (ex.Message);
            }
            }

        public async Task<bool> VerifyEmail(string email)
        {
            try {
                var user = await _context.Users
       .FirstOrDefaultAsync(u => u.Email == email);

                if (user != null)
                {
                    _logger.LogError("Email already exists.");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }


        public async Task<User> VerifyUser(string email)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    _logger.LogError("User not found");
                    return null;
                }
             
                

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<User> VerifyUserById(string userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == Guid.Parse(userId));


                if (user == null)
                {
                    _logger.LogError("User not found");
                    return null;
                }



                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public async Task<LoginResponse> LoginUser(User user)
        {
            try
            {
                if (user.Email == null)
                {
                    _logger.LogInformation("Email is required");
                   
                }
                if (user.Password == null)
                {
                    _logger.LogInformation("Password is required");
                   
                }
                if (user.Password.Length < 6)
                {
                    _logger.LogInformation("Password must contain six characteres");
                   
                }
                var token = _jwtService.GenerateToken(user);
                if (token == null)
                {
                    _logger.LogError("Error on creating authentication token");
                }
                return new LoginResponse { Email = user.Email, Fullname = user.Fullname, Message = "User logged in", Token = token,UserId=user.UserId };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new LoginResponse { Message=ex.Message};
            }
        }


        public async Task<string> AddCompany(User user,int CompanyId)
        {
            try
            {




                if (CompanyId== null)
                {
                    _logger.LogInformation("Company is required");
                    return "Company is required";

                }

                var token = _companyToken.GenerateTokenWithCompany(user,CompanyId);
                //if (token == null)
                //{
                //    _logger.LogError("Error on creating authentication token");
                //}
                return token;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return "Error on updating token";
            }
        }
    }
}
