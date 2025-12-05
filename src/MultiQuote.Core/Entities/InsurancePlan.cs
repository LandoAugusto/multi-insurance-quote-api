using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class InsurancePlan : IIdentityEntity
    {
        public int InsurancePlanId { get; set; }
        public int InsurancePlanTypeId { get; set; }
        public string? Description { get; set; }        
        public string? Image { get; set; }
        public bool IsPersonalized { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual InsurancePlanType InsurancePlanType { get; set; } = null!;
        public virtual ICollection<ProductInsurancePlan> ProductInsurancePlan { get; set; } = new HashSet<ProductInsurancePlan>();
    }
}
