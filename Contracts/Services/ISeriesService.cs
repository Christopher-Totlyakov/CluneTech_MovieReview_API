using Models.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services;

/// <summary>
/// Service contract for TV series.
/// </summary>
public interface ISeriesService
{
    Task<IEnumerable<SeriesDto>> GetAllSeriesAsync();
    Task<SeriesDto?> GetSeriesByIdAsync(long id);
    Task<SeriesDto> CreateSeriesAsync(CreateSeriesDto dto);
    Task<bool> UpdateSeriesAsync(long id, CreateSeriesDto dto);
    Task<bool> DeleteSeriesAsync(long id);

    Task<SeasonDto?> AddSeasonAsync(long seriesId, CreateSeasonDto dto);
    Task<bool> UpdateSeasonAsync(long seasonId, CreateSeasonDto dto);
    Task<bool> DeleteSeasonAsync(long seasonId);


    Task<EpisodeDto?> AddEpisodeAsync(long seasonId, CreateEpisodeDto dto);
    Task<bool> UpdateEpisodeAsync(long episodeId, CreateEpisodeDto dto);
    Task<bool> DeleteEpisodeAsync(long episodeId);
}
