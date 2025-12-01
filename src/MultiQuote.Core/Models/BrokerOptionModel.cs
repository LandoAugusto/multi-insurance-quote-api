namespace MultiQuoteApi.Core.Models
{
    public class BrokerOptionModel
    {
        public int BrokerId { get; set; }
        public int PersonId { get; set; }
        public required string SusepCode { get; set; }
        public required string Name { get; set; }
    }
}
