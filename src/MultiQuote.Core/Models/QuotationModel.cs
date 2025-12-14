namespace MultiQuoteApi.Core.Models
{
    public class QuotationModel
    {        
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
        public QuotationInsuredModel Insured { get; set; }
        public IEnumerable<QuotationItemModel> Items { get; set; }
    }
}
