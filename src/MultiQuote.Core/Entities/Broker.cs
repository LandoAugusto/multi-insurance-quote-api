using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class Broker : IIdentityEntity
    {
        public int BrokerId { get; set; }
        public int PersonId { get; set; }
        public required string SusepCode { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; } = DateTime.Now;
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<Quotation> Quotation { get; set; } = new HashSet<Quotation>();

    }
}

