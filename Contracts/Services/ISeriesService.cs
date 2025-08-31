using Models.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services;

/// <summary>
/// Service contract for managing TV series, seasons, and episodes.
/// </summary>
public interface ISeriesService
{
    /// <summary>
    /// Retrieves all TV series.
    /// </summary>
    /// <returns>A collection of <see cref="SeriesDto"/> objects.</returns>
    Task<IEnumerable<SeriesDto>> GetAllSeriesAsync();

    /// <summary>
    /// Retrieves a specific series by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the series.</param>
    /// <returns>The <see cref="SeriesDto"/> if found; otherwise, null.</returns>
    Task<SeriesDto?> GetSeriesByIdAsync(long id);

    /// <summary>
    /// Creates a new TV series.
    /// </summary>
    /// <param name="createSeriesDto">The details of the series to create.</param>
    /// <returns>The created <see cref="SeriesDto"/>.</returns>
    Task<SeriesDto> CreateSeriesAsync(CreateSeriesDto createSeriesDto);

    /// <summary>
    /// Updates an existing TV series.
    /// </summary>
    /// <param name="id">The unique identifier of the series to update.</param>
    /// <param name="updateSeriesDto">The updated series details.</param>
    /// <returns>True if the update was successful; otherwise, false.</returns>
    Task<bool> UpdateSeriesAsync(long id, UpdateSeriesDto updateSeriesDto);

    /// <summary>
    /// Deletes a TV series by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the series to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteSeriesAsync(long id);

    /// <summary>
    /// Adds a new season to a specific TV series.
    /// </summary>
    /// <param name="seriesId">The unique identifier of the series.</param>
    /// <param name="createSeasonDto">The details of the season to create.</param>
    /// <returns>The created <see cref="SeasonDto"/> if successful; otherwise, null.</returns>
    Task<SeasonDto?> AddSeasonAsync(long seriesId, CreateSeasonDto createSeasonDto);

    /// <summary>
    /// Updates an existing season.
    /// </summary>
    /// <param name="seasonId">The unique identifier of the season to update.</param>
    /// <param name="createSeasonDto">The updated season details.</param>
    /// <returns>True if the update was successful; otherwise, false.</returns>
    Task<bool> UpdateSeasonAsync(long seasonId, CreateSeasonDto createSeasonDto);

    /// <summary>
    /// Deletes a season by its unique identifier.
    /// </summary>
    /// <param name="seasonId">The unique identifier of the season to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteSeasonAsync(long seasonId);

    /// <summary>
    /// Adds a new episode to a specific season.
    /// </summary>
    /// <param name="seasonId">The unique identifier of the season.</param>
    /// <param name="createEpisodeDto">The details of the episode to create.</param>
    /// <returns>The created <see cref="EpisodeDto"/> if successful; otherwise, null.</returns>
    Task<EpisodeDto?> AddEpisodeAsync(long seasonId, CreateEpisodeDto createEpisodeDto);

    /// <summary>
    /// Updates an existing episode.
    /// </summary>
    /// <param name="episodeId">The unique identifier of the episode to update.</param>
    /// <param name="createEpisodeDto">The updated episode details.</param>
    /// <returns>True if the update was successful; otherwise, false.</returns>
    Task<bool> UpdateEpisodeAsync(long episodeId, CreateEpisodeDto createEpisodeDto);

    /// <summary>
    /// Deletes an episode by its unique identifier.
    /// </summary>
    /// <param name="episodeId">The unique identifier of the episode to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteEpisodeAsync(long episodeId);
}
