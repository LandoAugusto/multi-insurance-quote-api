using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class Product : IIdentityEntity
    {
        public int? ProductId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public int InsuranceBranchId { get; set; }        
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual InsuranceBranch InsuranceBranch { get; set; } = null!;
        public virtual ICollection<ProductAcceptance> ProductAcceptance { get; set; } = new HashSet<ProductAcceptance>();
        public virtual ICollection<ProductCalculationType> ProductCalculationType { get; set; } = new HashSet<ProductCalculationType>();
        public virtual ICollection<ProductQuestionnaire> ProductQuestion { get; set; } = new HashSet<ProductQuestionnaire>();
        public virtual ICollection<ProductCoverage> ProductCoverage { get; set; } = new HashSet<ProductCoverage>();
        public virtual ICollection<ProductAccessory> ProductAccessory { get; set; } = new HashSet<ProductAccessory>();
    }
}
