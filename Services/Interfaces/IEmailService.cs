using FluentEmail.Core.Models;

namespace CodeChallenge02.Services.Interfaces
{
    public interface IEmailService
    {
        public Task<SendResponse> SendEmail(EmailServiceVM emailServiceVM);
    }
}

