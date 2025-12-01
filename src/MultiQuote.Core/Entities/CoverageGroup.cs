using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class CoverageGroup : IIdentityEntity
    {
        public int CoverageGroupId { get; set; }
        public string Name { get; set; }
        public string LegacyCode { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<Coverage> Coverage { get; set; } = new HashSet<Coverage>();
    }
}
