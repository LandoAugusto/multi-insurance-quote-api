using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class QuestionResponseRepository(MultiQuoteDbContext context) : DomainRepository<QuestionResponse>(context),
        IQuestionResponseRepository
    {
        public async Task<IEnumerable<QuestionResponse>?> GetAsync(int questionId, RecordStatusEnum recordStatus)
        {
            var query = GenerateQuery(
                    filter: (filtr => filtr.QuestionId.Equals(questionId)
                    && filtr.Status.Equals((int)recordStatus)),
                     includeProperties: source =>
                                    source
                                    .Include(item => item.Response),
                    orderBy: item => item.OrderBy(y => y.Order));

            return await query.ToListAsync();
        }
    }
}
