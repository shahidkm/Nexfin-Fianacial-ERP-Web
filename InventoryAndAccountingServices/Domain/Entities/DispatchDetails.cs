namespace InventoryAndAccountingServices.Domain.Entities
{
    public class DispatchDetails
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        public Voucher Voucher { get; set; }

        public string DeliveryNoteNumber { get; set; }
        public DateTime? DispatchDate { get; set; }
        public string DispatchedThrough { get; set; } // e.g., Transport Name
        public string Destination { get; set; }
        public string LRNumber { get; set; } // Lorry Receipt No.
        public string VehicleNumber { get; set; }

        public decimal FreightCharges { get; set; }
    }
}
