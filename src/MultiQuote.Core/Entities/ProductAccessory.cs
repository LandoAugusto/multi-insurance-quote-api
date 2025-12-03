using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ProductAccessory : IIdentityEntity
    {
        public int ProductAccessoryId { get; set; }
        public int ProductId { get; set; }
        public int AccessoryId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Accessory Accessory { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
