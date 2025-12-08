using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class FranchiseCoverageType : IIdentityEntity
    {
        public int FranchiseCoverageTypeId { get; set; }
        public int CoverageTypeId { get; set; }
        public int FranchiseTypeId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual CoverageType CoverageType { get; set; } = null!;
        public virtual FranchiseType FranchiseType { get; set; } = null!;
        public virtual ICollection<FranchiseTypePercentage> FranchiseTypePercentage { get; set; } = new HashSet<FranchiseTypePercentage>();
        
    }
}
