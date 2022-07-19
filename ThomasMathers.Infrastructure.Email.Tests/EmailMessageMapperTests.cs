using ThomasMathers.Infrastructure.Email.Mappers;
using Xunit;

namespace ThomasMathers.Infrastructure.Email.Tests
{
    public class EmailMessageMapperTests
    {
        [Theory]
        [InlineData("admin", "admin@somewebsite.com", "Thomas Mathers", "thomas.mathers.pro@gmail.com", "Welcome", "Welcome to the site", "<html>Welcome to the site</html>")]
        public void Map_MapsCorrectly(
            string fromName, 
            string fromEmail, 
            string toName, 
            string toEmail, 
            string subject, 
            string body, 
            string bodyHtml
        )
        {
            // Arrange
            var emailMessage = new EmailMessage
            {
                From = new EmailAddress
                {
                    Name = fromName,
                    Email = fromEmail
                },
                To = new EmailAddress
                {
                    Name = toName,
                    Email = toEmail
                },
                Subject = subject,
                Body = body,
                BodyHtml = bodyHtml
            };

            // Act
            var actual = EmailMessageMapper.Map(emailMessage);

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.From);
            Assert.Equal(fromName, actual.From.Name);
            Assert.Equal(fromEmail, actual.From.Email);
            Assert.NotNull(actual.Personalizations);
            Assert.NotEmpty(actual.Personalizations);
            Assert.NotNull(actual.Personalizations[0].Tos);
            Assert.NotEmpty(actual.Personalizations[0].Tos);
            Assert.Equal(toName, actual.Personalizations[0].Tos[0].Name);
            Assert.Equal(toEmail, actual.Personalizations[0].Tos[0].Email);
            Assert.Equal(subject, actual.Subject);
            Assert.Equal(body, actual.PlainTextContent);
            Assert.Equal(bodyHtml, actual.HtmlContent);
        }
    }
}