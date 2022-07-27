using System.Text.Json;
using Microsoft.Extensions.Logging;
using SendGrid;
using ThomasMathers.Infrastructure.Email.Mappers;

namespace ThomasMathers.Infrastructure.Email.Services
{
    public class SendGridEmailService : IEmailService
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly ILogger<SendGridEmailService> _logger;

        public SendGridEmailService(ISendGridClient sendGridClient, ILogger<SendGridEmailService> logger)
        {
            _sendGridClient = sendGridClient;
            _logger = logger;
        }

        public Task SendEmailAsync(EmailMessage email)
        {
            var sendGridEmail = EmailMessageMapper.Map(email);
            var sendGridEmailJson = JsonSerializer.Serialize(sendGridEmail);
            _logger.LogInformation($"Sending email: {sendGridEmailJson}");
            return _sendGridClient.SendEmailAsync(sendGridEmail);
        }

        public Task SendTemplatedEmailAsync<T>(TemplateEmailMessage<T> email) where T : class
        {
            var sendGridEmail = TemplateEmailMessageMapper.Map(email);
            var sendGridEmailJson = JsonSerializer.Serialize(sendGridEmail);
            _logger.LogInformation($"Sending email: {sendGridEmailJson}");
            return _sendGridClient.SendEmailAsync(sendGridEmail);
        }
    }
}
