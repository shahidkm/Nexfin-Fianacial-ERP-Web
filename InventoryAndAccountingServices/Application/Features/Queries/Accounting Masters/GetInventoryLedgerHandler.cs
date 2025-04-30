using AutoMapper;
using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Contracts;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Queries.Accounting_Masters
{
    public class GetInventoryLedgerHandler : IRequestHandler<GetInventoryLedgerQuery, List<GetInventoryLedgerDto>>
    {

        private readonly IAccountingMastersRepositories _repository;
        private readonly IMapper _mapper;
        public GetInventoryLedgerHandler(IAccountingMastersRepositories accountingMastersRepository, IMapper mapper)
        {
            _repository = accountingMastersRepository;
            _mapper = mapper;
        }

        public async Task<List<GetInventoryLedgerDto>> Handle(GetInventoryLedgerQuery query, CancellationToken cancellationToken)
        {



            var response = await _repository.GetInventoryLedger(query.CompanyId);

            return response;
        }
    }
}
