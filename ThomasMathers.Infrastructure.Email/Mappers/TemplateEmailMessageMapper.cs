using SendGrid.Helpers.Mail;

namespace ThomasMathers.Infrastructure.Email.Mappers
{
    public static class TemplateEmailMessageMapper
    {
        public static SendGridMessage Map<T>(TemplateEmailMessage<T> emailMessage) where T : class
        {
            if (emailMessage == null)
            {
                throw new ArgumentNullException(nameof(emailMessage));
            }

            var message = new SendGridMessage
            {
                From = EmailAddressMapper.Map(emailMessage.From),
                Subject = emailMessage.Subject
            };

            message.AddTo(EmailAddressMapper.Map(emailMessage.To));
            message.SetTemplateId(emailMessage.TemplateId);
            message.SetTemplateData(emailMessage.Payload);

            return message;
        }
    }
}
