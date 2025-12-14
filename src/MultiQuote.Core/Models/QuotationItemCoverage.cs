using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Models
{
    public  class QuotationItemCoverage : IIdentityEntity
    {
        public int QuotationItemCoverageId { get; set; }
        public int QuotationItemId { get; set; }
        public int CoverageId { get; set; }
        public bool CoverageBasic { get; set; }
        public decimal InsuredAmountValue { get; set; }               
        public virtual QuotationItem Items { get; set; } = null!;
        public virtual Coverage Coverage { get; set; } = null!;     
    }
}
