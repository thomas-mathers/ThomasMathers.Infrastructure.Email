using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using ThomasMathers.Infrastructure.Email.Services;
using ThomasMathers.Infrastructure.Email.Settings;

namespace ThomasMathers.Infrastructure.Email.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEmailService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddEmailService(configuration.GetSection("EmailServiceSettings"));
        }

        public static void AddEmailService(this IServiceCollection serviceCollection, IConfigurationSection configurationSection)
        {
            serviceCollection.AddEmailService(EmailServiceSettings.FromConfigurationSection(configurationSection));
        }

        public static void AddEmailService(this IServiceCollection serviceCollection, EmailServiceSettings emailServiceSettings)
        {
            serviceCollection.AddLogging();
            serviceCollection.AddScoped<ISendGridClient>(_ => new SendGridClient(emailServiceSettings.SendGridApiKey));
            serviceCollection.AddScoped<IEmailService, SendGridEmailService>();
        }
    }
}
