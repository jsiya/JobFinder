using JobFinder.Application.Repositories.Common;
using JobFinder.Persistence.DbContexts;

namespace JobFinder.Persistence.Repositories.Common;

public class WriteGenericRepository<T>: GenericRepository<T>, IWriteGenericRepository<T> where T: class
{
    public WriteGenericRepository(ApplicationDbContext context) : 
        base(context)
    {
    }
    
    public async Task AddAsync(T entity)
    {
        await _table.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _table.Update(entity);
    }

    public void Remove(T entity)
    {
        
        if (_table.Find(entity) != null)
            _table.Remove(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }


}