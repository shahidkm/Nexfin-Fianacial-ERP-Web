using AutoMapper;
using CompanyServices.Application.Features.Quaries;
using CompanyServices.Application.Interfaces;
using MediatR;

namespace CompanyServices.Application.Features.Commands
{
    public class EditCompanyHandler : IRequestHandler<EditCompanyCommand, string>
  {        private readonly ICompanyRepository _companyRepository;  
            private readonly IMapper _mapper;

          public EditCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
          {
             _companyRepository = companyRepository;
             _mapper = mapper;
       }

       public async Task<string> Handle(EditCompanyCommand command, CancellationToken cancellationToken)
           {
            var response = await _companyRepository.EditCompany(command);
            return response;
          }
     }
}
