namespace MultiQuoteApi.Core.Infrastructure.Configuration
{
    public class PolicyConfig
    {
        public int? Retries { get; set; }

        public int? TimeoutMs { get; set; }

        public List<int> StatusCode { get; set; }
    }
}