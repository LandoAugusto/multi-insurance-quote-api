namespace MultiQuoteApi.Core.Models
{
    public class BrokerUserModel
    {
        public required string Name { get; set; }
        public required int PersonTypeId { get; set; }
        public required string Document { get; set; }
        public required int ProfileId { get; set; }
        public required CredencialModel Credencial { get; set; }
        public required AddressModel Address { get; set; }
        public required IEnumerable<ContactModel> Contact { get; set; }
    }
}
