using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using ThomasMathers.Infrastructure.Email.Services;
using ThomasMathers.Infrastructure.Email.Settings;

namespace ThomasMathers.Infrastructure.Email.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddEmailService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddEmailService(configuration.GetSection("EmailSettings"));
        }

        public static void AddEmailService(this IServiceCollection serviceCollection, IConfigurationSection configurationSection)
        {
            serviceCollection.AddEmailService(EmailSettings.FromConfigurationSection(configurationSection));
        }

        public static void AddEmailService(this IServiceCollection serviceCollection, EmailSettings emailSettings)
        {
            serviceCollection.AddScoped<ISendGridClient>(_ => new SendGridClient(emailSettings.SendGridApiKey));
            serviceCollection.AddScoped<IEmailService, SendGridEmailService>();
        }
    }
}
