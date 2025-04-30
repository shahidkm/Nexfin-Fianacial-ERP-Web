//using AutoMapper;
//using CompanyServices.Application.Interfaces;
//using CompanyServices.Domain.Entities;
//using MediatR;

//namespace CompanyServices.Application.Features.Quaries
//{
//    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, bool>
//    {
//        private readonly ICompanyRepository _companyRepository;
//        private readonly IMapper _mapper;

//        public GetCompanyByIdHandler(ICompanyRepository companyRepository, IMapper mapper)
//        {
//            _companyRepository = companyRepository;
//            _mapper = mapper;
//        }

//        public async Task<bool> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
//        {
//            var company = await _companyRepository.SelectCompany(request.CompanyId, request.UserId);
//            return company;
//        }
//    }
//}
