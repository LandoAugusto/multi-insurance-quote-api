namespace MultiQuoteApi.Core.Models
{
    public class GroupModel
    {
        public required int CoveragaGroupId { get; set; }
        public required string Name { get; set; }
        public List<CoverageGroupModel> Coverages { get; set; } =  [];
    }

    public class CoverageGroupModel
    {
        public int CoverageId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public CoverageLimitModel Limit { get; set; } = new CoverageLimitModel();
    }
}
