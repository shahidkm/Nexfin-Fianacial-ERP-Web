using InventoryAndAccountingServices.Contracts;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Queries.Accounting_Masters
{
    public class GetInventoryLedgerQuery : IRequest<List<GetInventoryLedgerDto>>
    {
        public int CompanyId { get; set; }
    }
}

