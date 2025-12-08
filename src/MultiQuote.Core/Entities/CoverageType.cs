using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class CoverageType : IIdentityEntity
    {
        public int CoverageTypeId { get; set; }
        public required string Name { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<FranchiseCoverageType> FranchiseCoverageType { get; set; } = new HashSet<FranchiseCoverageType>();
        
    }
}
