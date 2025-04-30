namespace CompanyServices.Domain.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string UserId { get; set; }
        public string? UserLicenseKey { get; set; }
        public string? UserLicenseStatus { get; set; }
        // Basic Info
        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string Pincode { get; set; }

        // Contact
        public string Phone { get; set; }
        public string Email { get; set; }

        // Tax Info
        public string GSTIN { get; set; }
        public string PAN { get; set; }

        // Financial Year
        public DateOnly FinancialYearFrom { get; set; }
        public DateOnly BooksBeginFrom { get; set; }

        // Audit
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public string Image { get; set; }
        // Navigation: Linked Data
        //public ICollection<CompanyRole> CompanyRoles { get; set; }
        //public ICollection<StockItem> StockItems { get; set; }
        //public ICollection<Voucher> Vouchers { get; set; }
        //public ICollection<Employee> Employees { get; set; }
    }
}
