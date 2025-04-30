using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetCompanyByUserHandler : IRequestHandler<GetCompanyByUserQuary, List<Company>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyByUserHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<Company>> Handle(GetCompanyByUserQuary request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.RetreiveCompanyByUser(request.UserId);
            return companies;
        }
    }
}
