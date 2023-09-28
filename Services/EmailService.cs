using CodeChallenge02.Services.Interfaces;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Smtp;
using System.Net.Mail;

namespace CodeChallenge02.Services
{
    public class EmailService : IEmailService
    {
        public async Task<SendResponse> SendEmail(EmailServiceVM emailServiceVM)
        {
            var sender = new SmtpSender(
                new SmtpClient("localhost")
                {
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                    PickupDirectoryLocation = @"C:\Users\Kaio\Desktop\EmailService"
                }
            );

            Email.DefaultSender = sender;

            var email = await Email
                .From(emailServiceVM.EmailSender)
                .To(emailServiceVM.EmailReceiver)
                .Subject(emailServiceVM.Subject)
                .Body(emailServiceVM.Body)
                .SendAsync();

            return email;

        }
    }
}
