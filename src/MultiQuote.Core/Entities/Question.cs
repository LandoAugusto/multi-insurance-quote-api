using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class Question : IIdentityEntity
    {
        public int QuestionId { get; set; }
        public required string Name { get; set; }
        public int ComponentTypeId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ComponentType ComponentType { get; set; } = null!;
        public virtual ICollection<QuestionResponse> QuestionResponse { get; set; } = new HashSet<QuestionResponse>();
        public virtual ICollection<ProductQuestionnaire> ProductQuestion { get; set; } = new HashSet<ProductQuestionnaire>();
        public virtual ICollection<QuotationItemQuestionnaire> Questionnaires { get; set; } = new HashSet<QuotationItemQuestionnaire>();
    }
}
