namespace InventoryAndAccountingServices.Application.Interfaces
{
    public interface ICompanyContext
    {
        int CompanyId { get; set; }
        string CompanyName { get; set; }
    }
}
