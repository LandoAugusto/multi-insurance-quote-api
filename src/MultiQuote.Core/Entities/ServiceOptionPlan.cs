using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ServiceOptionPlan : IIdentityEntity
    {
        public int ServiceOptionPlanId { get; set; }
        public required string Name { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<ProductCoverageTypeService> ProductCoverageTypeService { get; set; } = new HashSet<ProductCoverageTypeService>();
    }
}
