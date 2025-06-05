using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;
using InventoryAndAccountingServices.Domain.Enums;

namespace InventoryAndAccountingServices.Application.Interfaces
{
    public interface IVoucherRepository
    {
        Task<string> CreateVoucherAsync(CreateVoucherDto dto);
        Task<List<Voucher>> GetAllVouchersByCompanyIdAsync(int companyId);
        Task<List<Voucher>> GetDifferentVouchersByCompanyIdAsync(int companyId, VoucherType voucherType);
        Task<List<Voucher>> DayBook(int companyId);
    }
}
