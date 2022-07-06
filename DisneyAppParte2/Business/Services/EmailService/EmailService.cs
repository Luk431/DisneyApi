using DisneyAppParte2.Dtos.EmailDtos;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace DisneyAppParte2.Business.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly IMailjetClient _mailjetClient;
        public EmailService(IConfiguration config, IMailjetClient mailjetClient)
        {
            _config = config;
            _mailjetClient = mailjetClient;
        }
        
        public async void SendEmail(EmailDto registerRequest)
        {
            /*
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse();
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = ;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
            */

            MailjetClient client = new MailjetClient(_config.GetSection("apiKey").Value, _config.GetSection("apiSecret").Value);

            MailjetRequest request = new MailjetRequest()
            {
                Resource = Contact.Resource,
            }

            .Property(Contact.Email, "Mister@mailjet.com");

            // construct your email with builder
            var email = new TransactionalEmailBuilder()
                   .WithFrom(new SendContact(_config.GetSection("EmailUsername").Value))
                   .WithSubject(registerRequest.Subject)
                   .WithHtmlPart(registerRequest.Body)
                   .WithTo(new SendContact(registerRequest.To))
                   .Build();

            // invoke API to send email
            await _mailjetClient.SendTransactionalEmailAsync(email);
        }
    }
}
