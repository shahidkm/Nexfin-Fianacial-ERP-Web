namespace InventoryAndAccountingServices.Contracts
{
    public class GetInventoryLedgerDto
    {
        public string LedgerName { get; set; }

        public int CompanyId { get; set; }
        public string? Alias { get; set; }

        public string? GroupName { get; set; }

        public decimal? OpeningBalance { get; set; }

        public string? DrCr { get; set; }

        public decimal Balance { get; set; }
    }
}
