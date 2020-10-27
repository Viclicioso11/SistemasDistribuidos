using Application.Common.Interfaces;
using System;
using SendGrid;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmail(string to, string subject, string content)
        {
            var apiKey = _configuration.GetValue<string>("sengridData:apikey");

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(_configuration.GetValue<string>("sengridData:from"));

            var emailTo = new EmailAddress(to);

            var htmlContent = "";

            if (content != null)
            {
                htmlContent = $"<strong>Su OTP es {content}</strong>";
            }
            else
            {
                htmlContent = "<strong>Correo de prueba</strong>";
            }
            var plainTextContent = "and easy to do anywhere, even with C#";

            

            var msg = MailHelper.CreateSingleEmail(from, emailTo, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != HttpStatusCode.OK)
                return false;

            return true;
        }
    }
}
