using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ProductInsurancePlanCoverageLimit : IIdentityEntity
    {
        public int ProductInsurancePlanCoverageLimitId { get; set; }
        public int ProductInsurancePlanCoverageId { get; set; }
        public int ProfileId { get; set; }
        public decimal Amount { get; set; }
        public decimal InsuredAmountValueMin { get; set; }
        public decimal InsuredAmountValueMax { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Profile Profile { get; set; } = null!;
        public virtual ProductInsurancePlanCoverage ProductInsurancePlanCoverage { get; set; } = null!;
    }
}
