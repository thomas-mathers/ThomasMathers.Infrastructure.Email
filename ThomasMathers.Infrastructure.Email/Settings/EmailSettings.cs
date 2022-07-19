using Microsoft.Extensions.Configuration;

namespace ThomasMathers.Infrastructure.Email.Settings
{
    public record EmailSettings
    {
        public string SendGridApiKey { get; init; } = string.Empty;

        public EmailSettings(string sendGridApiKey) { SendGridApiKey = sendGridApiKey; }

        private EmailSettings() { }

        public static EmailSettings FromConfigurationSection(IConfigurationSection section)
        {
            var settings = new EmailSettings();
            section.Bind(settings);
            return settings;
        }
    }
}
