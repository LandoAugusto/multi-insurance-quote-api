using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ContactType : IIdentityEntity
    {
        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }

        public virtual ICollection<Contact> Contact { get; set; } = new HashSet<Contact>();
    }
}
