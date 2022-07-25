namespace ThomasMathers.Infrastructure.Email.Tests.MockObjects
{
    internal record WelcomeEmail
    {
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
    }
}
