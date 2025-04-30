namespace InventoryAndAccountingServices.Domain.Entities
{
    public class VoucherItem
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        public Voucher Voucher { get; set; }

        public int ItemId { get; set; }
        public StockItem Item { get; set; }

        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Total => Quantity * Rate;

        public GSTTaxDetail? GSTTaxDetail { get; set; }
    }
}
