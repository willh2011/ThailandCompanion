using System.Linq.Expressions;

namespace ThailandCompanion.Api.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    IQueryable<T> Query();

    Task<List<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task<bool> AnyAsync();

    Task AddRangeAsync(IEnumerable<T> entities);

    void Update(T entity);

    void Remove(T entity);
}