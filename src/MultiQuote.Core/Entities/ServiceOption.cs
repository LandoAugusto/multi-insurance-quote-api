using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ServiceOption : IIdentityEntity
    {
        public int ServiceOptionId { get; set; }
        public required string Name { get; set; }
        public int ServiceTypeId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ServiceType ServiceType { get; set; } = null!;
        public virtual ICollection<ProductCoverageTypeService> ProductCoverageTypeService { get; set; } = new HashSet<ProductCoverageTypeService>();
    }
}
