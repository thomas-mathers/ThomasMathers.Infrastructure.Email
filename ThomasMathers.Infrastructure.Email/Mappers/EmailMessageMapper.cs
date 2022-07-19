using SendGrid.Helpers.Mail;

namespace ThomasMathers.Infrastructure.Email.Mappers
{
    public static class EmailMessageMapper
    {
        public static SendGridMessage Map(EmailMessage emailMessage)
        {
            if (emailMessage == null)
            {
                throw new ArgumentNullException(nameof(emailMessage));
            }

            var message = new SendGridMessage
            {
                From = EmailAddressMapper.Map(emailMessage.From),
                Subject = emailMessage.Subject,
                PlainTextContent = emailMessage.Body,
                HtmlContent = emailMessage.BodyHtml
            };

            message.AddTo(EmailAddressMapper.Map(emailMessage.To));

            return message;
        }
    }
}
