namespace MultiQuoteApi.Core.Models
{
    public  class ContactModel
    {
        public required int ContactTypeId { get; set; }
        public required int ContactCategoryId { get; set; }
        public required string Value { get; set; }
        public string? Comments { get; set; }
    }
}
