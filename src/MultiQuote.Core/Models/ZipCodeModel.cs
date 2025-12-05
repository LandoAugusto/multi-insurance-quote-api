namespace MultiQuoteApi.Core.Models
{
    public class ZipCodeModel
    {
        public string? ZipCode { get; set; }
        public string? StreetName { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string State { get; set; }        
        public int StateId { get; set; }
        public string City { get; set; }
    }
}
