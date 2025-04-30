using AutoMapper;
using CompanyService.Application.Features.Quaries;
using CompanyService.Application.Features.Queries;
using CompanyService.Application.Interfaces;
using CompanyService.Domain.Entities;
using MediatR;

namespace CompanyService.Application.Features.Handlers
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyById, Company>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyByIdHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Company> Handle(GetCompanyById request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.SelectCompany(request.CompanyId, request.UserId);
            return company;
        }
    }
}
