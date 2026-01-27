using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VMT.CineHub.Domain.Repositories;
using VMT.CineHub.Persistence.Database;

namespace VMT.CineHub.Persistence.Repositories;

internal sealed class Repository<T>
(
    CineHubDbContext _dbContext
) : IRepository<T> where T : class
{
    private readonly CineHubDbContext dbContext = _dbContext;

    public async Task AddAsync(T entity) => await dbContext.Set<T>().AddAsync(entity);

    public void Delete(T entity) => dbContext.Set<T>().Remove(entity);

    public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate) => 
        await dbContext.Set<T>().FirstOrDefaultAsync(predicate);

    public void Update(T entity) => dbContext.Set<T>().Update(entity);
}