using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class QuestionResponse : IIdentityEntity
    {
        public int QuestionResponseId { get; set; }
        public int QuestionId { get; set; }
        public int ResponseId { get; set; }
        public int Order { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Question Question { get; set; } = null!;
        public virtual Response Response { get; set; } = null!;
    }
}
