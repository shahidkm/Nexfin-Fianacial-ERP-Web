namespace InventoryAndAccountingServices.Contracts
{
    public class CreateDispatchDetailsDto
    {
        public string DeliveryNoteNumber { get; set; }
        public DateTime? DispatchDate { get; set; }
        public string DispatchedThrough { get; set; }
        public string Destination { get; set; }
        public string LRNumber { get; set; }
        public string VehicleNumber { get; set; }
        public decimal FreightCharges { get; set; }
    }
}
