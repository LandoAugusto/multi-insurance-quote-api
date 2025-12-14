namespace MultiQuoteApi.Core.Models
{
    public class QuotationItemModel
    {
        public int QuotationItemId { get; set; }
        public int QuotationId { get; set; }
        public int NumberItem { get; set; }
        public int PlanId { get; set; }
        public int CoverageTypeId { get; set; }
        public int FranchiseTypeId { get; set; }
        public decimal FranchisePercentage { get; set; }
        public decimal FipePercentage { get; set; }
        public required QuotationDriverModel Driver { get; set; }
        public required QuotationItemAutoModel Auto { get; set; }
        public required IEnumerable<QuotationItemCoverageModel> Coverages { get; set; }
        public required IEnumerable<QuotationItemQuestionnaireModel> Questionnaires { get; set; }

    }
}

