namespace MultiQuoteApi.Core.Models
{
    public class CoverageModel
    {   
        public int CoverageId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int BranchId { get; set; }
        public int CoverageGroupId { get; set; }
        public bool CoverageBasic { get; set; }
        public int? CoverageRestricted { get; set; }
        public bool IsGoodsRelationship { get; set; }     
        public string? LegacyCode { get; set; }
    }
}
