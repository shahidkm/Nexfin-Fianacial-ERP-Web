using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Contracts;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetCompanyBasedRoleHandler : IRequestHandler<GetCompanyBasedRoleQuery, List<GetCompanyBasedRoleDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyBasedRoleHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCompanyBasedRoleDto>> Handle(GetCompanyBasedRoleQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.RetriveCompanyBasedRole(request);
            return company;
        }
    }
}
