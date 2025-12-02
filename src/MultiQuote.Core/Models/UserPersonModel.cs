namespace MultiQuoteApi.Core.Models
{
    public class UserPersonModel
    {
        public int BrokerId { get; set; }
        public int PersonId { get; set; }
        public int ProfileId { get; set; }        
        public required CredencialModel Credencial { get; set; }
    }
}
