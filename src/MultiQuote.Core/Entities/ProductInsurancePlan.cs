using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ProductInsurancePlan : IIdentityEntity
    {
        public int ProductInsurancePlanId { get; set; }
        public int ProductId { get; set; }
        public int InsurancePlanId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual InsurancePlan InsurancePlan { get; set; } = null!;
        public virtual ICollection<ProductInsurancePlanCoverage> ProductInsurancePlanCoverage { get; set; } = new HashSet<ProductInsurancePlanCoverage>();
    }
}
