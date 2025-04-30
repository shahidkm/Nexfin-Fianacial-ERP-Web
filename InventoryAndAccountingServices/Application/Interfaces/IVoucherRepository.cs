using InventoryAndAccountingServices.Contracts;

namespace InventoryAndAccountingServices.Application.Interfaces
{
    public interface IVoucherRepository
    {
        Task<string> CreateVoucherAsync(CreateVoucherDto dto);
    }
}
