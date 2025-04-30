using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Queries
{
    public class GetInventoryGroupQuery :IRequest<List<GetInventoryGroupsDto>>
    {
        public int CompanyId { get; set; }
    }
}
