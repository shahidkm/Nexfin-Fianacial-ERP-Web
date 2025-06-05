using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetEmployeeQuaryHandler : IRequestHandler<GetEmployeeQuary, List<CompanyRole>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetEmployeeQuaryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyRole>> Handle(GetEmployeeQuary request, CancellationToken cancellationToken)
        {
            var accountants = await _companyRepository.RetriveEmployees(request.CompanyId);


            return (accountants);
        }
    }
}
