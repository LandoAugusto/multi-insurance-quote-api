using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class RecordStatus : IIdentityEntity
    {
        public int RecordStatusId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }

    }
}
