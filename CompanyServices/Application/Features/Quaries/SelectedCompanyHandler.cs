using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetSelectedCompanyDataHandler : IRequestHandler<GetSelectedCompany, Company>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetSelectedCompanyDataHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Company> Handle(GetSelectedCompany request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.RetriveCompanyById(request.CompanyId);
         
            return company;
        }
    }
}
