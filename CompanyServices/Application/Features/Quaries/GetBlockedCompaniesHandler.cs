using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetBlockedCompaniesHandler : IRequestHandler<GetBlockedCompaniesQuery, List<Company>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetBlockedCompaniesHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<Company>> Handle(GetBlockedCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.RetriveBlockedCompanies();
            return companies;
        }
    }
}
