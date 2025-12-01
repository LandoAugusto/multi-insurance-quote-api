using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Repositories.Standard.Interfaces;

namespace MultiQuoteApi.Infra.Data.Interfaces
{
    public interface IQuestionResponseRepository : IDomainRepository<QuestionResponse>
    {
        Task<IEnumerable<QuestionResponse>?> GetAsync(int questionId, RecordStatusEnum recordStatus);
    }
}
