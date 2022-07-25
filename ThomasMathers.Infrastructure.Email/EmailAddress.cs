namespace ThomasMathers.Infrastructure.Email
{
    public record EmailAddress
    {
        public string Email { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;

        public EmailAddress()
        {

        }

        public EmailAddress(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
