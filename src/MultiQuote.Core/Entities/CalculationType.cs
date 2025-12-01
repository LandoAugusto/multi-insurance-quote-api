using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class CalculationType : IIdentityEntity
    {
        public int CalculationTypeId { get; set; }
        public required string Name { get; set; }
        public int Status { get; set; }
        public int? InclusionUserId { get; set; }
        public DateTime? InclusionDate { get; set; }
        public virtual ICollection<ProductCalculationType> ProductCalculationType { get; set; } = new HashSet<ProductCalculationType>();
    }
}
