using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ProductCalculationType : IIdentityEntity
    {
        public int ProductCalculationTypeId { get; set; }        
        public int ProductId { get; set; }
        public int ProfileId { get; set; }
        public int CalculationTypeId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual CalculationType CalculationType { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Profile Profile { get; set; } = null!;   
    }
}
