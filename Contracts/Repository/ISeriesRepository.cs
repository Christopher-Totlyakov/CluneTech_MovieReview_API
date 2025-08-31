using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

/// <summary>
/// Defines repository methods for working with <see cref="Series"/> entities.
/// </summary>
public interface ISeriesRepository : IRepositoryBase<Series>
{
    /// <summary>
    /// Retrieves all series including their associated reviews.
    /// </summary>
    /// <returns>A list of <see cref="Series"/> objects with reviews.</returns>
    Task<List<Series>> GetAllWithReviewsAsync();

    /// <summary>
    /// Retrieves a specific series by its unique identifier, including its reviews.
    /// </summary>
    /// <param name="id">The unique identifier of the series.</param>
    /// <returns>
    /// The <see cref="Series"/> with its reviews if found; otherwise, null.
    /// </returns>
    Task<Series?> GetSeriesWithReviewsAsync(long id);

    /// <summary>
    /// Retrieves a specific series by its unique identifier, including its seasons and episodes.
    /// </summary>
    /// <param name="id">The unique identifier of the series.</param>
    /// <returns>
    /// The <see cref="Series"/> with its seasons and episodes if found; otherwise, null.
    /// </returns>
    Task<Series?> GetSeriesWithSeasonsAndEpisodesAsync(long id);
}
