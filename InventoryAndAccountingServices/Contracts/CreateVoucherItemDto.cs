namespace InventoryAndAccountingServices.Contracts
{
    public class CreateVoucherItemDto
    {
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }

        public GSTTaxDetailDto? GST { get; set; }
    }
}
