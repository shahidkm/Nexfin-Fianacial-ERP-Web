namespace InventoryAndAccountingServices.Contracts
{
    public class ProfitAndLossDto
    {
        public List<ProfitAndLossLine> Income { get; set; } = new();
        public List<ProfitAndLossLine> Expenses { get; set; } = new();
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetProfitOrLoss { get; set; } // Positive = Profit, Negative = Loss
    }

}
