using AutoMapper;
using PayrollMasters.Domain.Entities;
using PayrollService.Application.Features.Commands;

namespace PayrollService.Application.Common.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<EmployeeCommand, Employee>();
        }
    }
}
