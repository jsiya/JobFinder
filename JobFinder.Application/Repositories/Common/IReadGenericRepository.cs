using System.Linq.Expressions;

namespace JobFinder.Application.Repositories.Common;

public interface IReadGenericRepository<T> : IGenericRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}