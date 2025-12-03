using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class Accessory : IIdentityEntity
    {
        public int AccessoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<ProductAccessory> ProductAccessory { get; set; } = new HashSet<ProductAccessory>();
    }
}
