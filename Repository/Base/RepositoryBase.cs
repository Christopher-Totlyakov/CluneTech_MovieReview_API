using System.Linq.Expressions;
using Contracts.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Repository.Base;

/// <summary>
/// Implements the asynchronous repository pattern for entity operations using EF Core.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly RepositoryContext context;

    public RepositoryBase(RepositoryContext context)
    {
        this.context = context;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>().Where(predicate).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    /// <inheritdoc />
    public async Task CreateAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        return await context.Set<T>().FindAsync(id);
    }
}
