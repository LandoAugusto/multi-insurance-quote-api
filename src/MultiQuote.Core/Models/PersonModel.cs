namespace MultiQuoteApi.Core.Models
{
    public class PersonModel
    {
        public long PersonId { get; set; }
        public int PersonTypeId { get; set; }
        public required string Document { get; set; }
        public  required string Name { get; set; }
        public bool? IsPublicBody { get; set; }
        public int? GenderId { get; set; }        
        public DateTime? BornDate { get; set; }
        public int? MaritalStatusId { get; set; }
        public IEnumerable<AddressModel>? Address { get; set; }
        public IEnumerable<ContactModel>? Contact { get; set; }
    }
}
