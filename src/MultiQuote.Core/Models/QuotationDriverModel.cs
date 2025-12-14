namespace MultiQuoteApi.Core.Models
{
    public class QuotationDriverModel
    {    
        public int DriverTypeId { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public int TimeCount { get; set; }

    }
}
