using AutoMapper;
using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands
{
    public class InventoryGroupHandler : IRequestHandler<InventoryGroupCommand, string>
    {

        private readonly IAccountingMastersRepositories _repository;
        private readonly IMapper _mapper;
        public InventoryGroupHandler(IAccountingMastersRepositories accountingMastersRepository, IMapper mapper)
        {
            _repository = accountingMastersRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(InventoryGroupCommand inventoryGroupCommand, CancellationToken cancellationToken)
        {
            var group = _mapper.Map<InventoryGroup>(inventoryGroupCommand);


            var response = await _repository.CreateInventoryGroup(group);

            return response;
        }
    }
}
