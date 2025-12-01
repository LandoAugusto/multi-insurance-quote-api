namespace MultiQuoteApi.Core.Models
{
    public class AddressModel
    {
        public required string ZipCode { get; set; }
        public required string StreetName { get; set; }
        public string? Complement { get; set; }
        public required string? District { get; set; }
        public string State { get; set; }
        public string StateUf { get; set; }
        public required string Number { get; set; }
        public int AddressTypeId { get; set; }        
        public required string City { get; set; }
    }
}
