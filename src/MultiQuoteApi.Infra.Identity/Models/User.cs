using MultiQuoteApi.Infra.Identity.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MultiQuoteApi.Infra.Identity.Models
{
    public class User(IHttpContextAccessor accessor) : IUser
    {
        private readonly IHttpContextAccessor _accessor = accessor;        

        public string? Name => _accessor?.HttpContext?.User?.Identity?.Name;

        public int GetUserId() => IsAuthenticated() ? int.Parse(_accessor.HttpContext.User.GetUserId()) : default;

        public string? GetUserEmail() => IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : string.Empty;

        public string? GetUserName() => IsAuthenticated() ? _accessor.HttpContext.User.GetUserName() : string.Empty;        

        public bool IsAuthenticated() => _accessor.HttpContext.User.Identity.IsAuthenticated;

        public int GetProfileId() => IsAuthenticated() ? int.Parse(_accessor.HttpContext.User.GetProfileId()) : default;

        public int GetBrokerId() => IsAuthenticated() ? int.Parse(_accessor.HttpContext.User.GetBrokerId()) : default;

        public bool IsInRole(string role) => _accessor.HttpContext.User.IsInRole(role);

        public IEnumerable<Claim> GetClaimsIdentity() => _accessor.HttpContext.User.Claims;

    }

    public static class ClaimsPrincipalExtensions
    {
        public static string? GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(null, nameof(principal));
            }
            var claim = principal.FindFirst("userId");
            if (claim == null) return null;
            return claim?.Value;
        }

        public static string? GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(null, nameof(principal));
            }
            var claim = principal.FindFirst(ClaimTypes.Email);
            if (claim == null) return null;
            return claim.Value;
        }

        public static string? GetUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(null, nameof(principal));
            }
            var claim = principal.FindFirst("userName");
            if (claim == null) return null;
            return claim.Value;
        }       

        public static string? GetProfileId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(null, nameof(principal));
            }
            var claim = principal.FindFirst("profileId");
            if (claim == null) return null;
            return claim.Value;
        }
        public static string? GetBrokerId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(null, nameof(principal));
            }
            var claim = principal.FindFirst("brokerId");
            if (claim == null) return null;
            return claim.Value;
        }
    }
}
