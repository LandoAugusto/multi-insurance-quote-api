namespace MultiQuoteApi.Core.Models.Auth
{
    public class TokenResponse
    {
        public string? AccessToken { get; set; }
        public double ExpiresIn { get; set; }
    }
}
