using System.Linq.Expressions;

namespace Contracts.Repository.Base;

/// <summary>
/// Defines the asynchronous contract for a generic repository that supports basic CRUD operations.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IRepositoryBase<T> where T : class
{
    /// <summary>
    /// Asynchronously retrieves all entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a collection of all entities.</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Asynchronously retrieves all entities of type <typeparamref name="T"/> that match the specified condition.
    /// </summary>
    /// <param name="predicate">The filter expression to apply.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a collection of matching entities.</returns>
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Asynchronously retrieves a single entity of type <typeparamref name="T"/> that matches the specified condition.
    /// </summary>
    /// <param name="predicate">The filter expression to apply.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the matching entity, or null if not found.</returns>
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Asynchronously adds a new entity of type <typeparamref name="T"/> to the data store.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateAsync(T entity);

    /// <summary>
    /// Asynchronously updates an existing entity of type <typeparamref name="T"/> in the data store.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Asynchronously removes an existing entity of type <typeparamref name="T"/> from the data store.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(T entity);

    /// <summary>
    /// Asynchronously retrieves an entity of type <typeparamref name="T"/> by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the entity if found, or null.</returns>
    Task<T?> GetByIdAsync(long id);
}
