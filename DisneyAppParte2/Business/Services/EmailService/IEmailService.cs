using DisneyAppParte2.Dtos.EmailDtos;

namespace DisneyAppParte2.Business.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
