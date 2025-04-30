using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetActiveCompaniesHandler : IRequestHandler<GetActiveCompaniesQuery, List<Company>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetActiveCompaniesHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<Company>> Handle(GetActiveCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.RetriveActiveCompanies();
            return companies;
        }
    }
}
