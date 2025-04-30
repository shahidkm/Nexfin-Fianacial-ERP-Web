using AutoMapper;
using CompanyServices.Application.Interfaces;
using MediatR;

namespace CompanyServices.Application.Features.Commands
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, string>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public DeleteCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteCompanyCommand command, CancellationToken cancellationToken)
        {
            var response = await _companyRepository.DeleteCompany(command.CompanyId);
            return response;
        }
    }
}
