using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Infra.Data.Contexts;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Data.Repositories.Standard;
using Microsoft.EntityFrameworkCore;

namespace MultiQuoteApi.Infra.Data.Repositories
{
    internal class MenuProductRepository(MultiQuoteDbContext context) : DomainRepository<MenuProduct>(context), IMenuProductRepository
    {
        public async Task<MenuProduct?> GetAsync(int code)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Code.Equals(code)),
                             includeProperties: source =>
                                    source
                                    .Include(item => item.MenuScreen)
                                    .ThenInclude(item => item.MenuComponent),
                            orderBy: item => item.OrderBy(y => y.Id)));

            return query.FirstOrDefault();
        }
    }
}
