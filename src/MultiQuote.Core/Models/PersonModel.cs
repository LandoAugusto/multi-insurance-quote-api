namespace MultiQuoteApi.Core.Models
{
    public class PersonModel
    {
        public long PersonId { get; set; }
        public int PersonTypeId { get; set; }
        public string? Document { get; set; }
        public string Name { get; set; }
        public string? IssuingBody { get; set; }
        public int? GenderId { get; set; }
        public bool? IsPublicBody { get; set; }
        public DateTime? BornDate { get; set; }
        public string? MaritalStatusId { get; set; }
        public IEnumerable<AddressModel>? Address { get; set; }
    }
}
