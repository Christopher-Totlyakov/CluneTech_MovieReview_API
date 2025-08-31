using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

/// <summary>
/// Defines repository methods for working with <see cref="Movie"/> entities.
/// </summary>
public interface IMovieRepository : IRepositoryBase<Movie>
{
    /// <summary>
    /// Retrieves a movie by its unique identifier, including its associated reviews.
    /// </summary>
    /// <param name="movieId">The unique identifier of the movie.</param>
    /// <returns>
    /// The <see cref="Movie"/> with its reviews if found; otherwise, null.
    /// </returns>
    Task<Movie?> GetMovieWithReviewsAsync(int movieId);
}
