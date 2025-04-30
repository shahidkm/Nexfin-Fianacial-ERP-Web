using AutoMapper;
using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands
{
    public class InventoryLedgerHandler : IRequestHandler<InventoryLedgerCommand, string>
    {

        private readonly IAccountingMastersRepositories _repository;
        private readonly IMapper _mapper;
        public InventoryLedgerHandler(IAccountingMastersRepositories accountingMastersRepository, IMapper mapper)
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
