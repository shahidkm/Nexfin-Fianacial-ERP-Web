using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetManagerQuaryHandler : IRequestHandler<GetManagerQuary, List<CompanyRole>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetManagerQuaryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyRole>> Handle(GetManagerQuary request, CancellationToken cancellationToken)
        {
            var accountants = await _companyRepository.RetriveManagers(request.CompanyId);


            return (accountants);
        }
    }
}
