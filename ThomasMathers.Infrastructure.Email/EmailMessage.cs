namespace ThomasMathers.Infrastructure.Email
{
    public record EmailMessage
    {
        public EmailAddress From { get; init; }
        public EmailAddress To { get; init; }
        public string Subject { get; init; }
        public string Body { get; init; }
        public string BodyHtml { get; init; }
    }
}
