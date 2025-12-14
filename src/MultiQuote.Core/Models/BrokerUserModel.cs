namespace MultiQuoteApi.Core.Models
{
    public class BrokerUserModel : BasePersonModel
    {       
        public required int ProfileId { get; set; }
        public required CredencialModel Credencial { get; set; }
    }
}
