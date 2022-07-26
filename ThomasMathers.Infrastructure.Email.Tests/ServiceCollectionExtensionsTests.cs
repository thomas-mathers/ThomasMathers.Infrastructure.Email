using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using ThomasMathers.Infrastructure.Email.Extensions;
using ThomasMathers.Infrastructure.Email.Services;
using ThomasMathers.Infrastructure.Email.Settings;
using Xunit;

namespace ThomasMathers.Infrastructure.Email.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddEmailService_RegistersRequiredServices()
        {
            // Arrange
            var services = new ServiceCollection();
            var emailSettings = new EmailServiceSettings("694127cc-c29a-44d3-9e6b-e1477efce59a");

            // Act
            services.AddEmailService(emailSettings);
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            Assert.NotNull(serviceProvider.GetRequiredService<ISendGridClient>());
            Assert.NotNull(serviceProvider.GetRequiredService<IEmailService>());
        }
    }
}