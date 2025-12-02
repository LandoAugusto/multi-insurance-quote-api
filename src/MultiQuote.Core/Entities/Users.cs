using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class Users : IIdentityEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BrokerId { get; set; }
        public int PersonId { get; set; }
        public int ProfileId { get; set; }
        public bool IsDefault { get; set; }        
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }

    }
}
