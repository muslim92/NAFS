using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace NAFS.Services.SendGridEmail
{
    public class EmailSender
    {
        public async Task SendEmail(string subject, string toEmail, string userName, string message)
        {
            var apiKey = "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";  //Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("muslimabbas@outlook.com", "NAFS Accoutants");
            var to = new EmailAddress(toEmail, userName);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
