using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using ThomasMathers.Infrastructure.Email.Extensions;
using ThomasMathers.Infrastructure.Email.Services;
using Xunit;

namespace ThomasMathers.Infrastructure.Email.Tests
{
    public class SendGridEmailServiceTests
    {
        private readonly IEmailService _sut;
        private readonly EmailAddress _from;
        private readonly EmailAddress _to;

        public SendGridEmailServiceTests()
        {
            var configuration = new ConfigurationBuilder().AddUserSecrets<SendGridEmailServiceTests>().Build();
            var services = new ServiceCollection();
            services.AddEmailService(configuration);
            var serviceProvider = services.BuildServiceProvider();
            _sut = serviceProvider.GetRequiredService<IEmailService>();
            _from = new EmailAddress(configuration["FromEmail"], configuration["FromName"]);
            _to = new EmailAddress(configuration["ToEmail"], configuration["ToName"]);
        }

        [Fact]
        public async Task SendEmailAsync_SendsCorrectly()
        {
            await _sut.SendEmailAsync(new EmailMessage
            {
                From = _from,
                To = _to,
                Subject = "Test Email Subject",
                Body = "Test Email Subject Body",
                BodyHtml = "<html><body><bold>Test Email Subject Body</bold></body></html>"
            });
        }
    }
}
