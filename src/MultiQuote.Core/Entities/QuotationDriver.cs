using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class QuotationDriver : IIdentityEntity
    {
        public int QuotationDriverId { get; set; }
        public int QuotationItemId { get; set; }
        public int DriverTypeId { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public int TimeCount { get; set; }
        public virtual QuotationItem QuotationItem { get; set; } = null!;
    }
}
