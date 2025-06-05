namespace PayrollService.Contracts
{
    public class DailySalaryDetailDto
    {
        public DateTime Date { get; set; }
        public string AttendanceType { get; set; } 
        public decimal Earnings { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetPay { get; set; }
    }

}
