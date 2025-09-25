using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace AuthSamples.Auth
{
    public class AdminHandler : AuthorizationHandler<AdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            if (context.User.HasClaim(c => /*c.Type == "role" &&*/ c.Value == requirement.Role))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
