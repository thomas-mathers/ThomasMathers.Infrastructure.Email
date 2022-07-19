namespace ThomasMathers.Infrastructure.Email.Mappers
{
    public static class EmailAddressMapper
    {
        public static SendGrid.Helpers.Mail.EmailAddress Map(EmailAddress emailAddress)
        {
            if (emailAddress == null)
            {
                throw new ArgumentNullException(nameof(emailAddress));
            }

            return new SendGrid.Helpers.Mail.EmailAddress
            {
                Name = emailAddress.Name,
                Email = emailAddress.Email
            };
        }
    }
}
