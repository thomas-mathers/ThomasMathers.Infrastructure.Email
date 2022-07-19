namespace ThomasMathers.Infrastructure.Email
{
    public record EmailAddress
    {
        public string Email { get; init; }
        public string Name { get; init; }

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
