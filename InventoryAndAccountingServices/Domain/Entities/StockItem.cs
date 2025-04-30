using System.ComponentModel.DataAnnotations;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class StockItem
    {
        [Key]
        public int ItemId { get; set; }

        public int CompanyId { get; set; }

        public string ItemName { get; set; }

        public int? GroupId { get; set; }

        public int? CategoryId { get; set; }

        public int ?UnitId { get; set; }

        public decimal? OpeningQty { get; set; }

        public decimal? OpeningRate { get; set; }
        public string? IsGstApplicable { get; set; }
        public string? HsnSacCode { get; set; }
        public string? GstRate { get; set; }
        public string? TypeOfSupply { get; set; }
        public decimal ?OpeningValue => OpeningQty * OpeningRate;

        public decimal ?Quantity { get; set; }  // ✅ Add this property to hold current quantity

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //public StockGroup Group { get; set; }

        //public StockCategory Category { get; set; }

        //public UnitOfMeasure Unit { get; set; }
    }
}
