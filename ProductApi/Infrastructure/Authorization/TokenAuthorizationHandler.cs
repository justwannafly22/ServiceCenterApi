using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure.Authorization
{
    public class TokenAuthorizationHandler : AuthorizationHandler<TokenRequirement>
    {
        public const string Policy = "TokenRequiredPolicy";

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TokenRequirement requirement)
        {
            if (context.User.Identity is { IsAuthenticated: true }) context.Succeed(requirement);
            else context.Fail();

            return Task.CompletedTask;
        }
    }
}
