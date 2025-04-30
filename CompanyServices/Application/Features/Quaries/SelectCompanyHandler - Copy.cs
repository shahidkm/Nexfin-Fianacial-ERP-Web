using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetSelectedCompanyHandler : IRequestHandler<GetSelectCompany, string>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetSelectedCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(GetSelectCompany request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.CheckCompany(request.CompanyId);
            if (company==null)
            {
                return ("Failed to select Company.");
            }
            return ("Company selected Successfully.");
        }
    }
}
