namespace MultiQuoteApi.Core.Models
{
    public class CalculateValidityFilterModel
    {
        public int ProductId { get; set; }  
        public int CalculationTypeId { get; set; }
        public int? CountDays { get; set; }
        public DateTime? StartCoverage { get; set; }
    }
}
