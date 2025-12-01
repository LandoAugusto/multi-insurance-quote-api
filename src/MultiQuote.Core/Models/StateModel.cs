namespace MultiQuoteApi.Core.Models
{
    public class StateModel
    {       
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string Initials { get; set; }
        public string? ExternalCode { get; set; }
        public string Name { get; set; }
        public string? Abbreviation { get; set; }
    }
}
