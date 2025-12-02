namespace MultiQuoteApi.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public int BrokerId { get; set; }
        public int ProfileId { get; set; }
        public bool IsDefault { get; set; }

    }
}
