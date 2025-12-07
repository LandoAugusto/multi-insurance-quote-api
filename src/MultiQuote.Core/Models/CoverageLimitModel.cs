namespace MultiQuoteApi.Core.Models
{
    public class CoverageLimitModel
    {
        public decimal Amount { get; set; }
        public decimal InsuredAmountMin { get; set; }
        public decimal InsuredAmountMax { get; set; }   
        public List<ValorItem> Values { get; set; } = [];
    }
                
    public class ValorItem
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
    }

}
