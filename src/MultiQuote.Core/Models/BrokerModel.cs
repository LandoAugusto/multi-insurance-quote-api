namespace MultiQuoteApi.Core.Models
{
    public class BrokerModel
    {
        public required string Name { get; set; }
        public string? Susep { get; set; }
        public required int PersonTypeId { get; set; }
        public required string Document { get; set; }
        public int? LicenseId { get; set; }
        public required CredencialModel Credencial { get; set; }
        public required IEnumerable<AddressModel> Address { get; set; }
        public required IEnumerable<ContactModel> Contact { get; set; }
    }
}
