using AutoMapper;
using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
    public class StockGroupHandler : IRequestHandler<StockGroupCommand, string>
    {

        private readonly IInventoryMastersRepository _repository;
        private readonly IMapper _mapper;
        public StockGroupHandler(IInventoryMastersRepository inventoryMastersRepository, IMapper mapper)
        {
            _repository = inventoryMastersRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(StockGroupCommand stockGroupCommand, CancellationToken cancellationToken)
        {
            var group = _mapper.Map<StockGroup>(stockGroupCommand);


            var response = await _repository.CreateStockGroup(group);

            return response;
        }
    }
}
