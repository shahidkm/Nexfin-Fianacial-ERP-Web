using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRolesQuery, List<CompanyRole>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetUserRoleQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyRole>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _companyRepository.RetriveUserRoles(request.Email);
            return roles;
        }
    }
}
