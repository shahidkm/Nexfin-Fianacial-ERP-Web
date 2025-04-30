namespace InventoryAndAccountingServices.Contracts
{
    public class GSTTaxDetailDto
    {
        public decimal CGSTPercent { get; set; }
        public decimal SGSTPercent { get; set; }
        public decimal IGSTPercent { get; set; }
    }
}
