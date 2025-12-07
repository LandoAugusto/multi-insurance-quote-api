namespace MultiQuoteApi.Core.Models
{
    public class InsurancePlanCoverageModel
    {
        public int CoverageId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int CoveragaGroupId { get; set; }   
        public CoverageLimitModel Limit { get; set; } = new CoverageLimitModel();
        
    }
}
