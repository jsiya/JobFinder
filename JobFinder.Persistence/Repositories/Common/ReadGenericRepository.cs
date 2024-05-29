using System.Linq.Expressions;
using JobFinder.Application.Repositories.Common;
using JobFinder.Persistence.DbContexts;

namespace JobFinder.Persistence.Repositories.Common;

public class ReadGenericRepository<T>: GenericRepository<T>, IReadGenericRepository<T> where T: class
{
    public ReadGenericRepository(ApplicationDbContext context)
    :base(context)
    {
        
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return _table;
    }

    public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return _table.Where(predicate);
    }
}