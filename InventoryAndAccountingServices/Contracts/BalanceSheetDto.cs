namespace InventoryAndAccountingServices.Contracts
{
    public class BalanceSheetDto
    {
        public List<BalanceSheetLine> Assets { get; set; } = new();
        public List<BalanceSheetLine> Liabilities { get; set; } = new();
        public decimal TotalAssets { get; set; }
        public decimal TotalLiabilities { get; set; }
    }

}
