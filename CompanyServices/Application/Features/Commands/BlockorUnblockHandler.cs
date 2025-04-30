using AutoMapper;
using CompanyServices.Application.Interfaces;
using MediatR;

namespace CompanyServices.Application.Features.Commands
{
    public class BlockorUnblockHandler : IRequestHandler<BlockorUnblockCommand, string>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public BlockorUnblockHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(BlockorUnblockCommand command, CancellationToken cancellationToken)
        {
            var response = await _companyRepository.BlockorUnblock(command.CompanyId);
            return response;
        }
    }
}
