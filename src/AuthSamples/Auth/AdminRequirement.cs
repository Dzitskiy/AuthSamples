using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace AuthSamples.Auth
{
    public class AdminRequirement : IAuthorizationRequirement
    {
        public AdminRequirement()
        {
        }

        public AdminRequirement(string role)
        {
            Role = role;
        }
        public string Role { get; }
    }
}
