using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ProductCoverageTypeService : IIdentityEntity
    {        
        public int ProductCoverageTypeServiceId { get; set; }
        public int ProductId { get; set; }
        public int CoverageTypeId{ get; set; }       
        public int ServiceOptionId { get; set; }
        public int ServiceOptionPlanId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual CoverageType CoverageType { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ServiceOption ServiceOption { get; set; } = null!;
        public virtual ServiceOptionPlan ServiceOptionPlan { get; set; } = null!;
    }
}
