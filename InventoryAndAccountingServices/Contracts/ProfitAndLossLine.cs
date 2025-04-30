namespace InventoryAndAccountingServices.Contracts
{
    public class ProfitAndLossLine
    {
        public string GroupName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public List<ProfitAndLossLine>? Children { get; set; }
    }
}
