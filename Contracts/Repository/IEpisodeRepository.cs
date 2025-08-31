using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

/// <summary>
/// Repository interface for managing <see cref="Episode"/> entities.
/// </summary>
public interface IEpisodeRepository : IRepositoryBase<Episode>
{
    /// <summary>
    /// Retrieves all episodes associated with a specific season.
    /// </summary>
    /// <param name="seasonId">The unique identifier of the season.</param>
    /// <returns>A collection of <see cref="Episode"/> objects.</returns>
    Task<IEnumerable<Episode>> GetBySeasonIdAsync(long seasonId);
}