namespace JobFinder.Application.Repositories.Common;

public interface IWriteGenericRepository<T>: IGenericRepository<T> where T: class
{
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    void SaveChanges();
}