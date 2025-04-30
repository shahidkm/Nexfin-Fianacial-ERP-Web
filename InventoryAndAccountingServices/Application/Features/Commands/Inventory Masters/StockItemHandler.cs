using AutoMapper;
using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
    public class StockItemHandler : IRequestHandler<StockItemCommand, string>
    {

        private readonly IInventoryMastersRepository _repository;
        private readonly IMapper _mapper;
        public StockItemHandler(IInventoryMastersRepository inventoryMastersRepository, IMapper mapper)
        {
            _repository = inventoryMastersRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(StockItemCommand stockItemCommand, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<StockItem>(stockItemCommand);


            var response = await _repository.CreateStockItem(item);

            return response;
        }
    }
}
