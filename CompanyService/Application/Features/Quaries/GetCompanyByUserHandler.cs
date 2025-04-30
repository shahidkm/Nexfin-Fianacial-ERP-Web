using AutoMapper;
using CompanyService.Application.Features.Queries;
using CompanyService.Application.Interfaces;
using CompanyService.Domain.Entities;
using MediatR;

namespace CompanyService.Application.Features.Handlers
{
    public class GetCompanyByUserHandler : IRequestHandler<GetCompanyByUser, List<Company>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyByUserHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<Company>> Handle(GetCompanyByUser request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.RetreiveCompanyByUser(request.UserId);
            return companies;
        }
    }
}
