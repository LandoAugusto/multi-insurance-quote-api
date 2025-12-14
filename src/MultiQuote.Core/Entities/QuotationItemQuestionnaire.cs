using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public class QuotationItemQuestionnaire : IIdentityEntity
    {
        public int QuotationItemQuestionnaireId { get; set; }
        public int QuotationItemId { get; set; }
        public int QuestionId { get; set; }
        public int ResponseId { get; set; }       
        public virtual QuotationItem QuotationItem { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
        public virtual Response QuestiResponseon { get; set; } = null!;
    }
}
