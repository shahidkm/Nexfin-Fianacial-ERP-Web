namespace InventoryAndAccountingServices.Domain.Entities
{
    public class GSTTaxDetail
    {
        public int Id { get; set; }
        public int VoucherItemId { get; set; }
        public VoucherItem VoucherItem { get; set; }

        public decimal CGSTPercent { get; set; }
        public decimal SGSTPercent { get; set; }
        public decimal IGSTPercent { get; set; }

        public decimal CGSTAmount => (VoucherItem.Total * CGSTPercent) / 100;
        public decimal SGSTAmount => (VoucherItem.Total * SGSTPercent) / 100;
        public decimal IGSTAmount => (VoucherItem.Total * IGSTPercent) / 100;
    }

}
