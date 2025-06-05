using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using PayrollService.Infrastucture.Persistence.Services.CloudinaryServices;

namespace PayrollService.Infrastucture.Persistence.Services
{
    public class CloudinaryService :ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration config)
        {
            var account = new Account(
                config["Cloudinary:CloudName"],
                config["Cloudinary:ApiKey"],
                config["Cloudinary:ApiSecret"]
            );

            _cloudinary = new Cloudinary(account);
        }


        public async Task<string> EmployeeImage(IFormFile file)
        {
            try
            {

                if (file == null)
                {
                    return "ImageAnalysis not found";
                }
                if (file.Length > 0)
                {
                    var useParams = new ImageUploadParams()
                    {


                        File = new FileDescription(file.Name, file.OpenReadStream())
                    };

                    var uploadedImage = await _cloudinary.UploadAsync(useParams);
                    return uploadedImage.SecureUrl.ToString();
                }
                return null;
            }
            catch (Exception ex)
            {

                return (ex.Message);
            }
        }
    }
}
