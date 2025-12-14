namespace MultiQuoteApi.Core.Models
{
    public class BrokerDetailsModel
    {
        public required int BrokerId { get; set; }
        public required string SusepCode { get; set; }
        public required int PersonId { get; set; }
        public required string Name { get; set; }
        public required int PersonTypeId { get; set; }
        public required string Document { get; set; }
        public required IEnumerable<AddressModel> Address { get; set; }
        public required IEnumerable<ContactModel> Contact { get; set; }
    }
}
