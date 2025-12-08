using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class FranchiseTypePercentage : IIdentityEntity
    {
        public int FranchiseTypePercentageId { get; set; }
        public int FranchiseCoverageTypeId { get; set; }
        public int Percentage { get; set; }        
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual FranchiseCoverageType FranchiseCoverageType { get; set; } = null!;
    }
}
