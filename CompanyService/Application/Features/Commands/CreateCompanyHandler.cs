using AutoMapper;
using CompanyService.Application.Interfaces;
using CompanyService.Domain.Entities;
using MediatR;  

namespace CompanyService.Application.Features.Commands
{
    public class CreateCompanyHandler : IRequestHandler<CompanyCommand, string>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CompanyCommand companyCommand, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(companyCommand);
            var response = await _companyRepository.CreateCompany(company);
            return response;
        }
    }
}
