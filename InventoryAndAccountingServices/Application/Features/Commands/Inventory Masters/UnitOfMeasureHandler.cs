using AutoMapper;
using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
    public class UnitOfMeasureHandler : IRequestHandler<UnitOfMeasureCommand, string>
    {

        private readonly IInventoryMastersRepository _repository;
        private readonly IMapper _mapper;
        public UnitOfMeasureHandler(IInventoryMastersRepository inventoryMastersRepository, IMapper mapper)
        {
            _repository = inventoryMastersRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UnitOfMeasureCommand unitOfMeasureCommand, CancellationToken cancellationToken)
        {
            var unit = _mapper.Map<UnitOfMeasure>(unitOfMeasureCommand);


            var response = await _repository.CreateUnitOfMeasure(unit);

            return response;
        }
    }
}
