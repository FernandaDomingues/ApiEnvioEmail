namespace Communication.Api.Infra.Services;

using Communication.Api.ViewModel;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

public class MailService : IMailService
{
    IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendMail(UserRequest request)
    {
        string emailFromAddress = _configuration.GetSection("ConfigEmail")["emailFromAddress"] ?? string.Empty;
        string smtpAddress = _configuration.GetSection("ConfigEmail")["smtpAddress"] ?? string.Empty;
        int portNumber = Convert.ToInt32(_configuration.GetSection("ConfigEmail")["portNumber"]);
        string password = _configuration.GetSection("ConfigEmail")["password"] ?? string.Empty;


        using (MailMessage mailMessage = new MailMessage())
        {
            mailMessage.From = new MailAddress(emailFromAddress);
            mailMessage.To.Add(request.Email);
            mailMessage.Subject = "Blog de Notícias - Confirmação de e-mail";
            mailMessage.Body = "Olá, " + request.Username + " por favor, confirme seu e-mail.";
            mailMessage.IsBodyHtml = false;
            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                smtp.Send(mailMessage);
            }
        }
    }
}
