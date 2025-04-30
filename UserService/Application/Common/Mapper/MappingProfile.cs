using AutoMapper;
using UserService.Application.Features.Commands;
using UserService.Contracts.DTOs.UserDTOs;
using UserService.Domain.Entities;
namespace UserService.Application.Common.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {

            CreateMap<RegisterUserCommand, User>();
            CreateMap<LoginCommand, User>();
        }
    }
}
