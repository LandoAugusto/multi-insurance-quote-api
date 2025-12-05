using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public  class Address : IIdentityEntity
    {
        public int AddressId { get; set; }
        public int PersonId { get; set; } 
        public int AddressTypeId { get; set; }      
        public bool IsMainAddress { get; set; }
        public string ZipCode { get; set; }
        public string StreetName { get; set; }
        public int StateId { get; set; }        
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string City { get; set; }        
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; } = DateTime.Now; 
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Person Person { get; set; } = null!;
        public virtual AddressType AddressType { get; set; } = null!;
        public virtual State State { get; set; } = null!;
    }
}
