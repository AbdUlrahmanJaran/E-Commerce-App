using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Electronics.Services
{
    public class EmailRepository
    {
        IConfiguration Configuration { get; set; }

        public EmailRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<bool> SendEmail(string message, string toEmail, string subject)
        {

            SendGridClient client = new SendGridClient(Configuration.GetConnectionString("AzureEmailAPIKey"));
            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("22029470@student.ltuc.com", "ElectronicsStore");
            msg.AddTo(toEmail);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, message);

            await client.SendEmailAsync(msg);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            return response.IsSuccessStatusCode;

        }

    }
}
