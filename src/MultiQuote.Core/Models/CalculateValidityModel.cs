namespace MultiQuoteApi.Core.Models
{
    public class CalculateValidityModel
    {
        public DateTime StartCoverage { get; set; }
        public DateTime EndCoverage { get; set; }
        public int CountDays { get; set; }
        public bool CountDaysEnable { get; set; }
    }
}
