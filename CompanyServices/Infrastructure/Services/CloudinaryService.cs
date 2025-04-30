using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Text;

namespace CompanyServices.Infrastructure.Services
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<string> CompanyImage(IFormFile file)
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