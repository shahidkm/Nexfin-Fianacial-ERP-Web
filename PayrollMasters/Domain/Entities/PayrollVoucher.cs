using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class PayrollVoucher
    {
        [Key]
        public int VoucherId { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime Date { get; set; }

        public ICollection<PayrollVoucherEntry> Entries { get; set; }
    }

}
