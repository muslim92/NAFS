using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace NAFS.Services.SendGridEmail
{
    public class EmailSender
    {
        public async Task SendEmail(string subject, string toEmail, string userName, string message)
        {
            //var apiKey = "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";
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("info@nafsaccountantslough.com", "NAFS Accoutants");
            var to = new EmailAddress(toEmail, userName);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
