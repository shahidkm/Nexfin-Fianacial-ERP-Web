using AutoMapper;
using MediatR;
using PayrollMasters.Application.Features.Commands;
using PayrollMasters.Application.Interfaces;
using PayrollMasters.Domain.Entities;
using PayrollService.Infrastucture.Persistence.Services.CloudinaryServices;

namespace PayrollService.Application.Features.Commands
{
    public class EmployeeHandler : IRequestHandler<EmployeeCommand, string>
    {

        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinary;

        public EmployeeHandler(IEmployeeRepository employeeRepository,IMapper mapper,ICloudinaryService cloudinaryService)
        {
            _repository = employeeRepository;
            _mapper = mapper;
            _cloudinary = cloudinaryService;
        }


        public async Task<string> Handle(EmployeeCommand request, CancellationToken cancellationToken)
        {
            var image=await _cloudinary.EmployeeImage(request.Image);
            var employee =  new Employee
            {
                FullName=request.FullName,
                Address=request.Address,
                CompanyId=request.CompanyId,
                GroupId=request.GroupId,
                Designation=request.Designation,
                DateOfBirth=request.DateOfBirth,
                Department=request.Department,
                BankAccountNumber=request.BankAccountNumber,
                BankName=request.BankName,
               BasicSalary=request.BasicSalary,
               Email=request.Email,
               Gender=request.Gender,
               Phone=request.Phone,
               IFSC=request.IFSC,
               Image=image
             };
            
            var result = await _repository.CreateEmployee(employee);
            return result;
        }
    }
}
