using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public  class Person : IIdentityEntity
    {
        public int PersonId { get; set; }
        public required int PersonTypeId { get; set; }
        public required string Document { get; set; }
        public required string Name { get; set; }
        public  bool? IsPublicBody { get; set; }
        public  int? GenderId { get; set; }
        public  DateTime? BornDate { get; set; }
        public int? MaritalStatusId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; } = DateTime.Now;
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual PersonType PersonType { get; set; } = null!;     
        public virtual ICollection<Address> Address { get; set; } = new HashSet<Address>();
        public virtual ICollection<Contact> Contact { get; set; } = new HashSet<Contact>();
        public virtual ICollection<Broker> Broker { get; set; } = new HashSet<Broker>();
        public virtual ICollection<Users> Users { get; set; } = new HashSet<Users>();
        public virtual ICollection<Quotation> Quotation { get; set; } = new HashSet<Quotation>();
    }
}
