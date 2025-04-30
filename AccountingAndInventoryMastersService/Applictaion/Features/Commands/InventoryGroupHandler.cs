using AccountingAndInventoryMastersService.Applictaion.Interfaces;
using AccountingAndInventoryMastersService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AccountingAndInventoryMastersService.Applictaion.Features.Commands
{
    public class InventoryGroupHandler : IRequestHandler<InventoryGroupCommand,string>
    {

        private readonly IAccountingMastersRepository _repository;
        private readonly IMapper _mapper;
        public InventoryGroupHandler(IAccountingMastersRepository accountingMastersRepository,IMapper mapper)
        {
            _repository = accountingMastersRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(InventoryGroupCommand inventoryGroupCommand,CancellationToken cancellationToken)
        {
            var group = _mapper.Map<InventoryGroup>(inventoryGroupCommand);
           

            var response = await _repository.CreateInventoryGroup(group);

            return response;
        }
    }
}
