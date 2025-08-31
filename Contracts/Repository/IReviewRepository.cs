using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

/// <summary>
/// Defines repository methods for working with <see cref="Review"/> entities.
/// </summary>
public interface IReviewRepository : IRepositoryBase<Review>
{
    /// <summary>
    /// Retrieves all reviews associated with a specific movie.
    /// </summary>
    /// <param name="movieId">The unique identifier of the movie.</param>
    /// <returns>
    /// A collection of <see cref="Review"/> objects for the specified movie.
    /// </returns>
    Task<IEnumerable<Review>> GetReviewsForMovieAsync(long movieId);
}
