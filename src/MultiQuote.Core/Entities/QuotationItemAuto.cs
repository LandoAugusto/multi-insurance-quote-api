using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class QuotationItemAuto : IIdentityEntity
    {
        public int QuotationItemAutoId { get; set; }
        public int QuotationItemId { get; set; }
        public required string Fipe { get; set; }
        public required string Plate { get; set; }
        public required string Chassi { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public int VersionId { get; set; }
        public int Year { get; set; }
        public int FuelTypeId { get; set; }
        public decimal Value { get; set; }
        public int AntiTheftDeviceId { get; set; }
        public int TrackerId { get; set; }
        public required string ZipCodeNight { get; set; }
        public bool IsZeroKm { get; set; }
        public bool IsAlienated { get; set; }
        public bool IsKitGas { get; set; }        
        public virtual QuotationItem QuotationItem { get; set; } = null!;        
    }
}
