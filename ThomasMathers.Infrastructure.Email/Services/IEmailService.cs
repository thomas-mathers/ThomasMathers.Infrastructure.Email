namespace ThomasMathers.Infrastructure.Email.Services
{
    public interface IEmailService
    {
        public Task SendEmailAsync(EmailMessage email);
        public Task SendTemplatedEmailAsync<T>(TemplateEmailMessage<T> email) where T : class;
    }
}
