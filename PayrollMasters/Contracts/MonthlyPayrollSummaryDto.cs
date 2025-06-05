namespace PayrollService.Contracts
{
    public class MonthlyPayrollSummaryDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string GroupName { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetPay { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }

        // New property to include payhead details (type and amount)
        public List<PayHeadDetailDto> PayHeadDetails { get; set; } = new List<PayHeadDetailDto>();
    }
}
