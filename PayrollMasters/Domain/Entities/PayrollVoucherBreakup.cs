using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class PayrollVoucherBreakup
    {
        [Key]
        public int Id { get; set; }
        public int EntryId { get; set; }
        public int PayHeadId { get; set; }
        public decimal Amount { get; set; }

        public PayrollVoucherEntry Entry { get; set; }
        public PayHead PayHead { get; set; }
    }

}
