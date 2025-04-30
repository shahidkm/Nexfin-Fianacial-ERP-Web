namespace InventoryAndAccountingServices.Contracts
{
    public class BankDetailsDto
    {
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSC { get; set; }
        public string BranchName { get; set; }
    }

}
