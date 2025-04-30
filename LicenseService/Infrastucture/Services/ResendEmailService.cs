namespace LicenseService.Infrastucture.Services
{
    using System.Net;
    using System.Net.Http.Headers;
    using System.Net.Mail;
    using System.Text;
    using System.Text.Json;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Configuration;

    public class ResendEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
     
        public ResendEmailService(IConfiguration config)
        {
            _apiKey = config["Resend:ApiKey"];
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.resend.com/");
           
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string htmlContent)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("shahidpvt80@gmail.com", "wvzt dgpk woez kqxt"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("shahidpvt80@gmail.com"),
                Subject = subject,
                Body = htmlContent,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(to);

            smtpClient.SendMailAsync(mailMessage);


            return true;
        }

       

    }

}
