namespace ThomasMathers.Infrastructure.Email
{
    public record TemplateEmailMessage<T> where T : class
    {
        public EmailAddress From { get; init; }
        public EmailAddress To { get; init; }
        public string Subject { get; init; }    
        public string TemplateId { get; init; }
        public T Payload { get; init; }
    }
}
