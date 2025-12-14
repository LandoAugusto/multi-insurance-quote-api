using MultiQuoteApi.Core.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiQuoteApi.Core.Entities
{
    public class Quotation : IIdentityEntity
    {
        public int QuotationId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuotationNumber { get; set; }
        public int EndorsementId { get; set; }
        public int VersionNumber { get; set; } = 1;
        public int ProductId { get; set; }
        public int BrokerId { get; set; }
        public int InsuranceTypeId { get; set; }
        public int QuotationStatusId { get; set; }
        public DateTime QuotationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsCalculated { get; set; }
        public int CalculationTypeId { get; set; }
        public DateTime StartCoverage { get; set; }
        public DateTime EndCoverage { get; set; }
        public int? RenovationInsurerId { get; set; }
        public string? RenovationPolicyNumber { get; set; }
        public DateTime? RenovationEndCoverage { get; set; }
        public int? RenovationClaimsCount { get; set; }
        public int? RenovationBonusClass { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; } = DateTime.Now;
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<QuotationItem> Items { get; set; } = new HashSet<QuotationItem>();
        public void SetInclusionUser(int inclusionUser)
        {
            InclusionUserId = inclusionUser;
            InclusionDate = DateTime.Now;            
        }
    }
}
