using System.ComponentModel.DataAnnotations;

namespace PayrollMasters.Domain.Entities
{
    public class PayrollVoucherEntry
    {
        [Key]
        public int EntryId { get; set; }
        public int VoucherId { get; set; }
        public int EmployeeId { get; set; }

        public decimal TotalEarnings { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetSalary => TotalEarnings - TotalDeductions;

        public PayrollVoucher Voucher { get; set; }
        public Employee Employee { get; set; }
        public ICollection<PayrollVoucherBreakup> Breakups { get; set; }
    }

}
