using System.Threading.Tasks;

namespace BusinessLayer.EmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htlmMessage);
    }
}
