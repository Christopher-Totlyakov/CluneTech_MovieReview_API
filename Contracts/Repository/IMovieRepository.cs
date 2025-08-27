using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

/// <summary>
/// Defines repository methods for working with movies.
/// </summary>
public interface IMovieRepository : IRepositoryBase<Movie>
{
    /// <summary>
    /// Gets a movie including its reviews by ID.
    /// </summary>
    Task<Movie?> GetMovieWithReviewsAsync(int movieId);
}

