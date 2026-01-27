using System.Linq.Expressions;

namespace VMT.CineHub.Domain.Repositories;
public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
    void Update(T entity);
    void Delete(T entity);
}