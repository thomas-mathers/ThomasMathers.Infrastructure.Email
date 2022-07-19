using SendGrid;
using ThomasMathers.Infrastructure.Email.Mappers;

namespace ThomasMathers.Infrastructure.Email.Services
{
    public class SendGridEmailService : IEmailService
    {
        private readonly ISendGridClient _sendGridClient;

        public SendGridEmailService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public Task SendEmailAsync(EmailMessage email)
        {
            return _sendGridClient.SendEmailAsync(EmailMessageMapper.Map(email));
        }

        public Task SendTemplatedEmailAsync<T>(TemplateEmailMessage<T> email) where T : class
        {
            return _sendGridClient.SendEmailAsync(TemplateEmailMessageMapper.Map(email));
        }
    }
}
