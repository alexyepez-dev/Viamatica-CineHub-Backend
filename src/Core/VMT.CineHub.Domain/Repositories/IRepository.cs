namespace VMT.CineHub.Domain.Repositories;
public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task<T> GetByAsync(string term);
    void Update(T entity);
    void Delete(T entity);
}