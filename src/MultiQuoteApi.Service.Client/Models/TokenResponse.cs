namespace MultiQuoteApi.Service.Client.Models
{
    public class TokenResponse
    {
        public string? AccessToken { get; set; }
        public double ExpiresIn { get; set; }
    }
}
