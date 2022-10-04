using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BusinessLayer.EmailServices
{
    public class EmailSender_ : IEmailSender
    {
        private string _host;
        private int _port;
        private bool _enableSSl;
        private string _userName;
        private string _password;

        public EmailSender_(string host, int port, bool enableSSl, string userName, string password) //bunlar smtp server için olması gereken koşullar
        {
            _host = host;
            _port = port;
            _enableSSl = enableSSl;
            _userName = userName;
            _password = password;
        }

        public Task SendEmailAsync(string email, string subject, string htlmMessage)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_userName, _password),
                EnableSsl = _enableSSl,
            };
            return client.SendMailAsync(new MailMessage(_userName, email, subject, htlmMessage)
            {
                IsBodyHtml = true
            });

        }
    }
}
