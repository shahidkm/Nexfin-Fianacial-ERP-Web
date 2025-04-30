using MediatR;

namespace CompanyServices.Application.Features.Commands
{

    public class EditCompanyCommand : IRequest<string>
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Pincode { get; set; }
        public string GSTIN { get; set; }
        public string PAN { get; set; }
        public DateOnly FinancialYearFrom { get; set; }
        public DateOnly BooksBeginFrom { get; set; }
    }
}
