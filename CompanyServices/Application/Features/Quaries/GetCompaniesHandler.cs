using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetCompaniesHandler : IRequestHandler<GetCompanyQuery, List<Company>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompaniesHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<Company>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.RetriveAllCompanies();
            return companies;
        }
    }
}
