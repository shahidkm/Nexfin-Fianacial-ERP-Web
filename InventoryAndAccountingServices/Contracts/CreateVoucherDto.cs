using InventoryAndAccountingServices.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAndAccountingServices.Contracts
{
    public class CreateVoucherDto
    {
        public int CompanyId { get; set; }
        public string VoucherNumber { get; set; }

        public VoucherType Type { get; set; }
        public DateTime Date { get; set; }
        public string Narration { get; set; }

        
        public List<CreateVoucherEntryDto> Entries { get; set; } = new();

       
        public List<CreateVoucherItemDto>? Items { get; set; }

       
        public CreateDispatchDetailsDto? DispatchDetails { get; set; }
    }

}
