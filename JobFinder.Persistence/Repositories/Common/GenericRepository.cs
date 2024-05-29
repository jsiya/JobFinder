using JobFinder.Application.Repositories.Common;
using JobFinder.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Persistence.Repositories.Common;

public class GenericRepository<T>: IGenericRepository<T> where T: class
{
    protected readonly ApplicationDbContext _context;
    protected DbSet<T> _table;
    
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
}