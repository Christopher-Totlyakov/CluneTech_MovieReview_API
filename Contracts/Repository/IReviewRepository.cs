using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

/// <summary>
/// Defines repository methods for working with reviews.
/// </summary>
public interface IReviewRepository : IRepositoryBase<Review>
{
    /// <summary>
    /// Gets all reviews for a specific movie.
    /// </summary>
    Task<IEnumerable<Review>> GetReviewsForMovieAsync(long movieId);
}