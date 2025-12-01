using System.Security.Claims;

namespace MultiQuoteApi.Infra.Identity.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        int GetUserId();
        int GetProfileId();
        string? GetUserEmail();
        string? GetUserName();
        int? GetExternalId();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
