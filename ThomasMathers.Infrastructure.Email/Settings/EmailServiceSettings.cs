using Microsoft.Extensions.Configuration;

namespace ThomasMathers.Infrastructure.Email.Settings
{
    public record EmailServiceSettings
    {
        public string SendGridApiKey { get; init; } = string.Empty;

        public EmailServiceSettings(string sendGridApiKey) { SendGridApiKey = sendGridApiKey; }

        private EmailServiceSettings() { }

        public static EmailServiceSettings FromConfigurationSection(IConfigurationSection section)
        {
            var settings = new EmailServiceSettings();
            section.Bind(settings);
            return settings;
        }
    }
}
