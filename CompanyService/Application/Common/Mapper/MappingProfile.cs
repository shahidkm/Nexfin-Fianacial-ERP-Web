using AutoMapper;
using CompanyService.Application.Features.Commands;
using CompanyService.Domain.Entities;

namespace CompanyService.Application.Common.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyCommand, Company>();
            CreateMap<CreateCompanyRoles, CompanyRole>();
        }
    }
}
