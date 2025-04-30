//using InventoryAndAccountingServices.Domain.Enums;
//using MediatR;

//namespace InventoryAndAccountingServices.Application.Features.Commands.Vouchers
//{
//    public class CreateVoucherCommand :IRequest<string>
//    {
//        public string VoucherNumber { get; set; }
//        public VoucherType Type { get; set; }
//        public DateTime Date { get; set; }
//        public string Narration { get; set; }

//        public List<CreateVoucherEntryDto> Entries { get; set; } = new();
//        public List<CreateVoucherItemDto>? Items { get; set; }
//        public CreateDispatchDetailsDto? DispatchDetails { get; set; }
//    }
//}
