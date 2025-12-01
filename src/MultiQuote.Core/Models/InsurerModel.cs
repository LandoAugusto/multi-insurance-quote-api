namespace MultiQuoteApi.Core.Models
{
    public class InsurerModel
    {
        public int InsurerId { get; set; }
        public required string Name { get; set; }
        public required string CodeNumber { get; set; }
        public string Image { get; set; }
        public decimal Commission { get; set; }
        public decimal Discount { get; set; }
    }
}
