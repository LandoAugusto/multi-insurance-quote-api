using MultiQuoteApi.Core.Entities.Interfaces;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Core.Entities
{
    public  class QuotationItem : IIdentityEntity
    {
        public int QuotationItemId { get; set; }
        public int QuotationId { get; set; }
        public int NumberItem { get; set; }
        public int PlanId { get; set; }
        public int CoverageTypeId { get; set; }
        public int FranchiseTypeId { get; set; }
        public decimal FranchisePercentage { get; set; }
        public decimal FipePercentage { get; set; }    
        public virtual Quotation Quotation { get; set; } = null!;
        public virtual QuotationDriver Driver { get; set; } = null!;
        public virtual QuotationItemAuto Auto { get; set; } = null!;
        public virtual ICollection<QuotationItemCoverage> Coverages { get; set; } = new HashSet<QuotationItemCoverage>();
        public virtual ICollection<QuotationItemQuestionnaire> Questionnaires { get; set; } = new HashSet<QuotationItemQuestionnaire>();           
    }
}
        