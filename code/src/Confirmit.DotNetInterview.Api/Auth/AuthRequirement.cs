using Microsoft.AspNetCore.Authorization;

namespace Confirmit.DotNetInterview.Api.Auth
{
    public class AuthRequirement : IAuthorizationRequirement
    {
        public bool WriteAccess { get; set; } = false;
    }
}
