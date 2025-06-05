namespace PayrollService.Contracts
{
    public class GetEmployeeDetailsDto
    {
        public int EmployeeId { get; set; }
   
        public string FullName { get; set; }
        public string? Designation { get; set; }
         public string Image { get; set; }
    
    }
}
