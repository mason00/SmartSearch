using Microsoft.AspNetCore.Authorization;

namespace Woolworths.Groot.SmartSearch.Services
{
    public class MyApiHandler : AuthorizationHandler<MyApiRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MyApiRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
