namespace ThomasMathers.Infrastructure.Email
{
    public record TemplateEmailMessage<T> where T : class
    {
        public EmailAddress From { get; init; } = new();
        public EmailAddress To { get; init; } = new();
        public string Subject { get; init; } = string.Empty;
        public string TemplateId { get; init; } = string.Empty;
        public T Payload { get; init; } = default!;
    }
}
