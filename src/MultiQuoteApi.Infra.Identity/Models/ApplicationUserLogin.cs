using Microsoft.AspNetCore.Identity;

namespace MultiQuoteApi.Infra.Identity.Models
{
    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
