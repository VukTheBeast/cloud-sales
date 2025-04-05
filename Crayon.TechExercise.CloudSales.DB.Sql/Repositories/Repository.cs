using Crayon.TechExercise.CloudSales.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Crayon.TechExercise.CloudSales.DB.Sql.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, Entities.IEntity
{
    private readonly CloudSalesContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    public Repository(CloudSalesContext dBContext)
    {
        _dbContext = dBContext;
        _dbSet = dBContext.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        return _dbContext.SaveChangesAsync();
    }

    public Task RemoveAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        return _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public Task<int> CountAllAsync() => _dbSet.CountAsync();

    public Task<int> CountWhereAsync(Expression<Func<TEntity, bool>> predicate)
        => _dbSet.CountAsync(predicate);
}
