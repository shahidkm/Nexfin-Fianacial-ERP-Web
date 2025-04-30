namespace InventoryAndAccountingServices.Contracts
{
    public class BalanceSheetLine
    {
        public string GroupName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public List<BalanceSheetLine>? Children { get; set; }
    }

}
