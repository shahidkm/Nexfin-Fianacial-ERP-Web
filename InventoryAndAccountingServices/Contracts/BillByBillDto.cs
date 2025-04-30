namespace InventoryAndAccountingServices.Contracts
{
    public class BillByBillDetailsDto
    {
        public bool IsBillByBillEnabled { get; set; }
        public int CreditPeriod { get; set; }
        public string ReferenceType { get; set; }
    }
}
