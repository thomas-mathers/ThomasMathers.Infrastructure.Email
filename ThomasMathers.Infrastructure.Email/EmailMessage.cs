namespace ThomasMathers.Infrastructure.Email
{
    public record EmailMessage
    {
        public EmailAddress From { get; init; } = new();
        public EmailAddress To { get; init; } = new();
        public string Subject { get; init; } = string.Empty;
        public string Body { get; init; } = string.Empty;
        public string BodyHtml { get; init; } = string.Empty;
    }
}
