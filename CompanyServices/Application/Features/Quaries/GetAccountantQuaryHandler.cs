using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetAccountantQuaryHandler : IRequestHandler<GetAccountantQuary, List<CompanyRole>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetAccountantQuaryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyRole>> Handle(GetAccountantQuary request, CancellationToken cancellationToken)
        {
            var accountants = await _companyRepository.RetriveAccountants(request.CompanyId);


            return (accountants);
        }
    }
}
