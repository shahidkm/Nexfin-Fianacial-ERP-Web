namespace PayrollService.Contracts
{
    public class CreatePayHeadDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string CalculationType { get; set; }
        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }
        public int? AttendanceTypeId { get; set; }
    }
}