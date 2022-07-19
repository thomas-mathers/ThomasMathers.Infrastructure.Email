using ThomasMathers.Infrastructure.Email.Mappers;
using ThomasMathers.Infrastructure.Email.Tests.MockObjects;
using Xunit;

namespace ThomasMathers.Infrastructure.Email.Tests
{
    public class TemplateEmailMessageMapperTests
    {
        [Theory]
        [InlineData("admin", "admin@somewebsite.com", "Thomas Mathers", "thomas.mathers.pro@gmail.com", "d-fae75ff448234360b9825e5f2a763899")]
        public void Map_MapsCorrectly(
            string fromName,
            string fromEmail,
            string toName,
            string toEmail,
            string templateId
        )
        {
            // Arrange
            var templateData = new WelcomeEmail
            {
                Name = toName,
                Email = toEmail
            };
            var emailMessage = new TemplateEmailMessage<WelcomeEmail>
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
                TemplateId = templateId,
                Payload = templateData
            };

            // Act
            var actual = TemplateEmailMessageMapper.Map(emailMessage);

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
            Assert.Equal(templateId, actual.TemplateId);
            Assert.Equal(templateData, actual.Personalizations[0].TemplateData);
        }
    }
}
