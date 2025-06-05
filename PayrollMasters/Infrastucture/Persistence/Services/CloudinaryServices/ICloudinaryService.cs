namespace PayrollService.Infrastucture.Persistence.Services.CloudinaryServices
{
    public interface ICloudinaryService
    {
        public Task<string> EmployeeImage(IFormFile file);
    }
}
