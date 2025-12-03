namespace MultiQuoteApi.Core.Entities
{
    public class Profile
    {
        public int? ProfileId { get; set; }
        public required string Description { get; set; }
        public int? Status { get; set; }        
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<ProductCalculationType> ProductCalculationType { get; set; } = new HashSet<ProductCalculationType>();
        public virtual ICollection<ProductCoverageLimit> ProductCoverageLimit { get; set; } = new HashSet<ProductCoverageLimit>();
    }
}
