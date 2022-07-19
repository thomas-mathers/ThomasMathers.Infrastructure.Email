using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasMathers.Infrastructure.Email.Tests.MockObjects
{
    internal record WelcomeEmail
    {
        public string Name { get; init; }
        public string Email { get; init; }
    }
}
