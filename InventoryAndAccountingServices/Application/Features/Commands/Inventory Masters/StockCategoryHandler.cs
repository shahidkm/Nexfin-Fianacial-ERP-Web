using AutoMapper;
using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
    public class StockCategoryHandler : IRequestHandler<StockCategoryCommand, string>
    {

        private readonly IInventoryMastersRepository _repository;
        private readonly IMapper _mapper;
        public StockCategoryHandler(IInventoryMastersRepository inventoryMastersRepository, IMapper mapper)
        {
            _repository = inventoryMastersRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(StockCategoryCommand stockCategoryCommand, CancellationToken cancellationToken)
        {
            var group = _mapper.Map<StockCategory>(stockCategoryCommand);


            var response = await _repository.CreateStockCategory(group);

            return response;
        }
    }
}
