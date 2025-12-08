namespace MultiQuoteApi.Core.Models
{
    public class CoverageLimitModel
    {
        public decimal Amount { get; set; }
        public decimal InsuredAmountValueMin { get; set; }
        public decimal InsuredAmountValueMax { get; set; }   
        public List<ValorItem> Values { get; set; } = [];
    }
                
    public class ValorItem
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
    }

}
