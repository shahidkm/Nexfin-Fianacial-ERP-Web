using AutoMapper;
using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
    public class GodownHandler : IRequestHandler<GodownCommand, string>
    {

        private readonly IInventoryMastersRepository _repository;
        private readonly IMapper _mapper;
        public GodownHandler(IInventoryMastersRepository inventoryMastersRepository, IMapper mapper)
        {
            _repository = inventoryMastersRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(GodownCommand godownCommand, CancellationToken cancellationToken)
        {
            var godown = _mapper.Map<Godown>(godownCommand);


            var response = await _repository.CreateGodown(godown);

            return response;
        }
    }
}
