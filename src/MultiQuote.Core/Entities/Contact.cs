using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class Contact : IIdentityEntity
    {
        public int ContactId { get; set; }
        public int PersonId { get; set; }
        public int ContactCategoryId { get; set; }
        public int ContactTypeId { get; set; }
        public required string Value { get; set; }
        public string? Comments { get; set; }
        public int Status { get; set; } 
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set;  } = DateTime.Now;
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Person Person { get; set; } = null!;
        public virtual ContactCategory ContactCategory { get; set; } = null!;
        public virtual ContactType ContactType { get; set; } = null!;
    }
}
