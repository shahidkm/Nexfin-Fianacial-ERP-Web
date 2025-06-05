namespace PayrollService.Contracts
{

    public class AddEmployeeDto
    {
      
        public int GroupId { get; set; }
        public string FullName { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? IFSC { get; set; }
        public decimal BasicSalary { get; set; }
        public IFormFile Image { get; set; }
    }
}
