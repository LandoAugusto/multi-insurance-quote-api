using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public  class InsuranceBranch : IIdentityEntity
    {
        public int InsuranceBranchId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BranchId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<Product> Product { get; set; } = new HashSet<Product>();
    }
}
