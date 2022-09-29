using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Email
{
    public class EmailHelper
    {

            public bool SendEmail(string userEmail, string message)
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("rabbitjumpedtwice@outlook.com");
                mailMessage.To.Add(new MailAddress(userEmail));

                mailMessage.Subject = "Confirm your email";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = message;

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("rabbitjumpedtwice@outlook.com", "123123123Aa");
                client.Host = "smtp-mail.outlook.com";
                client.Port = 587;
                client.EnableSsl = true;


                try
                {
                    client.SendMailAsync(mailMessage);
                    return true;
                }
                catch (Exception ex)
                {
                    //log exception
                }
                return false;
            }
      



    }
}
