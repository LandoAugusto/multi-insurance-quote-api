namespace MultiQuoteApi.Core.Models
{
    public class QuestionnaireModel
    {
        public int QuestionId { get; set; }
        public required string Name { get; set; }
        public int ComponentTypeId { get; set; }
        public List<ResponseModel>? Response { get; set; } = [];
    }
}
