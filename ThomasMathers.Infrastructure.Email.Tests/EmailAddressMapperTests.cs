using ThomasMathers.Infrastructure.Email.Mappers;
using Xunit;

namespace ThomasMathers.Infrastructure.Email.Tests
{
    public class EmailAddressMapperTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData("Thomas Mathers", "thomas.mathers.pro@gmail.com")]
        public void Map_MapsCorrectly(string name, string email)
        {
            // Arrange
            var emailAddress = new EmailAddress
            {
                Name = name,
                Email = email
            };

            // Act
            var actual = EmailAddressMapper.Map(emailAddress);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(name, actual.Name);
            Assert.Equal(email, actual.Email);
        }
    }
}