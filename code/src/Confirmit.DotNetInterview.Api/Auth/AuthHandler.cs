using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Confirmit.DotNetInterview.Api.Auth
{
    public class AuthHandler : AuthorizationHandler<AuthRequirement>
    {
        private const string AuthTokenHeader = "X-Confirmit-DotNetInterviewAuthToken";
        private const string WritePermissionHeader = "X-Confirmit-DotNetInterviewWritePermission";
        private const string ValidAuthToken = "12345-abcd-9876";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (!httpContext.Request.Headers.ContainsKey(AuthTokenHeader))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var incomingToken = httpContext.Request.Headers[AuthTokenHeader].ToString();
            if (string.IsNullOrEmpty(incomingToken) || incomingToken != ValidAuthToken)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if (!requirement.WriteAccess)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            if (!httpContext.Request.Headers.ContainsKey(WritePermissionHeader))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var writePermission = httpContext.Request.Headers[WritePermissionHeader].ToString();
            if (writePermission == "true")
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}
