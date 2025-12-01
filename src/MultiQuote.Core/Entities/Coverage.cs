using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class Coverage : IIdentityEntity
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
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Branch Branch { get; set; } = null!;
        public virtual CoverageGroup CoverageGroup { get; set; } = null!;
       
    }
}
