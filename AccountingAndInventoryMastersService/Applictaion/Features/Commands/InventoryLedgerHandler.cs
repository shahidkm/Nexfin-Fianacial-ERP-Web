using AccountingAndInventoryMastersService.Applictaion.Interfaces;
using AccountingAndInventoryMastersService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AccountingAndInventoryMastersService.Applictaion.Features.Commands
{
    public class InventoryLedgerHandler : IRequestHandler<InventoryLedgerCommand, string>
    {

        private readonly IAccountingMastersRepository _repository;
        private readonly IMapper _mapper;
        public InventoryLedgerHandler(IAccountingMastersRepository accountingMastersRepository, IMapper mapper)
        {
            _repository = accountingMastersRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(InventoryLedgerCommand inventoryLedgerCommand, CancellationToken cancellationToken)
        {
            var ledger = _mapper.Map<InventoryLedger>(inventoryLedgerCommand);


            var response = await _repository.CreateInventoryLedger(ledger);

            return response;
        }
    }
}
