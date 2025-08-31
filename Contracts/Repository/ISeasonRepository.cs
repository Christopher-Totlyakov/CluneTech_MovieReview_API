using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

/// <summary>
/// Repository interface for managing <see cref="Season"/> entities.
/// </summary>
public interface ISeasonRepository : IRepositoryBase<Season>
{
    /// <summary>
    /// Retrieves a season by its unique identifier including its episodes.
    /// </summary>
    /// <param name="id">The unique identifier of the season.</param>
    /// <returns>The <see cref="Season"/> with its episodes if found; otherwise, null.</returns>
    Task<Season?> GetByIdWithEpisodesAsync(long id);

    /// <summary>
    /// Retrieves all seasons associated with a specific series.
    /// </summary>
    /// <param name="seriesId">The unique identifier of the series.</param>
    /// <returns>A collection of <see cref="Season"/> objects.</returns>
    Task<IEnumerable<Season>> GetBySeriesIdAsync(long seriesId);
}
