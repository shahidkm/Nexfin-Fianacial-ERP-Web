using AutoMapper;
using CompanyServices.Application.Features.Commands;
using CompanyServices.Domain.Entities;

namespace CompanyServices.Application.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommand,Company>();
            CreateMap<CreateCompanyRoles, CompanyRole>();
        }
    }
}
