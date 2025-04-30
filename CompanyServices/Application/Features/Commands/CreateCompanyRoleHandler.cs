using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Commands
{
    public class CreateCompanyRoleHandler : IRequestHandler<CreateCompanyRoles, string>
    {
        private readonly ICompanyRepository  _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyRoleHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateCompanyRoles createCompanyRoles, CancellationToken cancellationToken)
        {
            var key = await _companyRepository.GenerateRoleKey(createCompanyRoles.Email, createCompanyRoles.CompanyId);
            var company = _mapper.Map<CompanyRole>(createCompanyRoles);
            company.Key = key;
            var response = await _companyRepository.CreateCompanyRole(company);
            return response;
        }
    }
}
