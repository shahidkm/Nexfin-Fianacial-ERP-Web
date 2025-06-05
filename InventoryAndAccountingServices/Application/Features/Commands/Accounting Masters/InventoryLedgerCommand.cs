using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands
{
    public record InventoryLedgerCommand(
        int LedgerId,
        int CompanyId,
        string LedgerName,
        string? Alias,
        int GroupId,
        decimal? OpeningBalance,
        string DrCr,
        BankDetailsDto  ? BankDetails,
         GstDetailsDto  ? GstDetails,
        BillByBillDetailsDto  ? BillByBillDetails
    ) : IRequest<string>;
}
