using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public  class ProductInsurancePlanCoverage : IIdentityEntity
    {
        public int ProductInsurancePlanCoverageId {  get; set; }
        public int ProductInsurancePlanId { get; set; }
        public int ProductCoverageId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ProductCoverage ProductCoverage { get; set; } = null!;
        public virtual ProductInsurancePlan ProductInsurancePlan { get; set; } = null!;
        public virtual ICollection<ProductInsurancePlanCoverageLimit> ProductInsurancePlanCoverageLimit { get; set; } = new HashSet<ProductInsurancePlanCoverageLimit>();
    }
}
