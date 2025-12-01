using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class ProductQuestionnaire : IIdentityEntity
    {
        public int ProductQuestionnaireId { get; set; }
        public int ProductId { get; set; }
        public int QuestionId { get; set; }
        public int Order { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
    }
}
