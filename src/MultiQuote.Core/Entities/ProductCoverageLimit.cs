using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ProductCoverageLimit : IIdentityEntity
    {
        public int ProductCoverageLimitId { get; set; }
        public int ProductCoverageId { get; set; }
        public int ProfileId { get; set; }
        public decimal Amount { get; set; }
        public decimal InsuredAmountMin { get; set; }
        public decimal InsuredAmountMax { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ProductCoverage ProductCoverage { get; set; } = null!;
        public virtual Profile Profile { get; set; } = null!;
    }
}
