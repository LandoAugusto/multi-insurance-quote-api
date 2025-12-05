namespace MultiQuoteApi.Core.Models
{
    public class InsurancePlanOptionModel
    {
        public int InsurancePlanId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Image { get; set; }
        public bool IsPersonalized { get; set; }
    }
}
