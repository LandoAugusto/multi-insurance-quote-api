using System.Security.Claims;

namespace MultiQuoteApi.Infra.Identity.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        int GetUserId();
        int GetProfileId();
        int GetBrokerId();
        string? GetUserEmail();
        string? GetUserName();        
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
