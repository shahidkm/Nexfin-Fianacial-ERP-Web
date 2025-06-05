using MediatR;
using System;

namespace PayrollService.Application.Features.Commands
{
    public record EmployeeCommand(int CompanyId,int GroupId, string FullName, string? Designation, string? Department, DateTime DateOfBirth, string Gender, string Phone, string Email, string Address, string? BankName, string? BankAccountNumber, string? IFSC, decimal BasicSalary,IFormFile Image) : IRequest<string>;
}
