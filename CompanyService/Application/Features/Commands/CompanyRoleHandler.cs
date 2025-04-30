using AutoMapper;
using CompanyService.Application.Interfaces;
using CompanyService.Domain.Entities;
using MediatR;

namespace CompanyService.Application.Features.Commands
{
    public class CompanyRoleHandler : IRequestHandler<CreateCompanyRoles, string>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyRoleHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateCompanyRoles createCompanyRoles, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<CompanyRole>(createCompanyRoles);
            var response = await _companyRepository.CreateCompanyRole(company);
            return response;
        }
    }
}
