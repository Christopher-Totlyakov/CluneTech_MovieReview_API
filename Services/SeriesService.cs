using Contracts.Repository;
using Contracts.Services;
using Entities;
using Models.Review;
using Models.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class SeriesService : ISeriesService
{
    private readonly ISeriesRepository _seriesRepository;
    private readonly ISeasonRepository _seasonRepository;
    private readonly IEpisodeRepository _episodeRepository;

    public SeriesService(
        ISeriesRepository seriesRepository,
        ISeasonRepository seasonRepository,
        IEpisodeRepository episodeRepository)
    {
        _seriesRepository = seriesRepository;
        _seasonRepository = seasonRepository;
        _episodeRepository = episodeRepository;
    }

    public async Task<IEnumerable<SeriesDto>> GetAllSeriesAsync()
    {
        var seriesList = await _seriesRepository.GetAllWithReviewsAsync();

        return seriesList.Select(s => new SeriesDto
        {
            Id = s.Id,
            Title = s.Title,
            Description = s.Description,
            Genre = s.Genre,
            ReleaseDate = s.ReleaseDate,
            PosterUrl = s.PosterUrl,
            AverageRating = s.AverageRating,
            Seasons = s.Seasons.Select(season => new SeasonDto
            {
                Id = season.Id,
                SeasonNumber = season.SeasonNumber,
                Title = season.Title,
                Description = season.Description,
                ReleaseDate = season.ReleaseDate,
                PosterUrl = season.PosterUrl,
                Episodes = season.Episodes.Select(ep => new EpisodeDto
                {
                    Id = ep.Id,
                    EpisodeNumber = ep.EpisodeNumber,
                    Title = ep.Title,
                    AirDate = ep.AirDate,
                    DurationMinutes = ep.DurationMinutes,
                    Description = ep.Description
                }).ToList()
            }).ToList(),
            Reviews = s.Reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Comment = r.Comment,
                Rating = r.Rating,
                UserName = r.User?.UserName ?? "Unknown",
                MovieId = r.MovieId,
                SeriesId = r.SeriesId
            }).ToList()
        });
    }

    public async Task<SeriesDto?> GetSeriesByIdAsync(long id)
    {
        if (id <= 0)
            throw new ValidationException("Invalid series id.");

        var series = await _seriesRepository.GetSeriesWithReviewsAsync(id);
        if (series == null) return null;

        return new SeriesDto
        {
            Id = series.Id,
            Title = series.Title,
            Description = series.Description,
            Genre = series.Genre,
            ReleaseDate = series.ReleaseDate,
            AverageRating = series.AverageRating,
            Reviews = series.Reviews.Select(review => new ReviewDto
            {
                Id = review.Id,
                Comment = review.Comment,
                Rating = review.Rating,
                UserName = review.User?.UserName ?? "Unknown",
                SeriesId = review.SeriesId
            }).ToList(),
            Seasons = series.Seasons.Select(season => new SeasonDto
            {
                Id = season.Id,
                SeasonNumber = season.SeasonNumber,
                Title = season.Title,
                Description = season.Description,
                ReleaseDate = season.ReleaseDate,
                PosterUrl = season.PosterUrl,
                Episodes = season.Episodes.Select(episode => new EpisodeDto
                {
                    Id = episode.Id,
                    EpisodeNumber = episode.EpisodeNumber,
                    Title = episode.Title,
                    AirDate = episode.AirDate,
                    DurationMinutes = episode.DurationMinutes,
                    Description = episode.Description
                }).ToList()
            }).ToList()
        };
    }

    public async Task<SeriesDto> CreateSeriesAsync(CreateSeriesDto createSeriesDto)
    {
        var series = new Series
        {
            Title = createSeriesDto.Title,
            Description = createSeriesDto.Description,
            Genre = createSeriesDto.Genre,
            ReleaseDate = createSeriesDto.ReleaseDate,
            PosterUrl = createSeriesDto.PosterUrl
        };

        foreach (var seasonDto in createSeriesDto.Seasons)
        {
            var season = new Season
            {
                SeasonNumber = seasonDto.SeasonNumber,
                Title = seasonDto.Title,
                Description = seasonDto.Description,
                ReleaseDate = seasonDto.ReleaseDate,
                PosterUrl = seasonDto.PosterUrl,
            };

            foreach (var episodeDto in seasonDto.Episodes)
            {
                var episode = new Episode
                {
                    EpisodeNumber = episodeDto.EpisodeNumber,
                    Title = episodeDto.Title,
                    AirDate = episodeDto.AirDate,
                    DurationMinutes = episodeDto.DurationMinutes,
                    Description = episodeDto.Description
                };
                season.Episodes.Add(episode);
            }

            series.Seasons.Add(season);
        }

        await _seriesRepository.CreateAsync(series);

        return new SeriesDto
        {
            Id = series.Id,
            Title = series.Title,
            Description = series.Description,
            Genre = series.Genre,
            ReleaseDate = series.ReleaseDate,
            PosterUrl = series.PosterUrl,
            AverageRating = series.AverageRating,
            Seasons = series.Seasons.Select(season => new SeasonDto
            {
                Id = season.Id,
                SeasonNumber = season.SeasonNumber,
                Title = season.Title,
                Description = season.Description,
                ReleaseDate = season.ReleaseDate,
                PosterUrl = season.PosterUrl,
                Episodes = season.Episodes.Select(episode => new EpisodeDto
                {
                    Id = episode.Id,
                    EpisodeNumber = episode.EpisodeNumber,
                    Title = episode.Title,
                    AirDate = episode.AirDate,
                    DurationMinutes = episode.DurationMinutes,
                    Description = episode.Description
                }).ToList()
            }).ToList(),
            Reviews = new List<ReviewDto>()
        };
    }

    public async Task<bool> UpdateSeriesAsync(long id, UpdateSeriesDto createSeriesDto)
    {
        if (id <= 0)
            throw new ValidationException("Invalid series id.");

        var series = await _seriesRepository.GetByIdAsync(id);
        if (series == null) return false;

        series.Title = createSeriesDto.Title;
        series.Description = createSeriesDto.Description;
        series.Genre = createSeriesDto.Genre;
        series.ReleaseDate = createSeriesDto.ReleaseDate;
        series.PosterUrl = createSeriesDto.PosterUrl;

        await _seriesRepository.UpdateAsync(series);
        return true;
    }

    public async Task<bool> DeleteSeriesAsync(long id)
    {
        if (id <= 0)
            throw new ValidationException("Invalid series id.");

        var series = await _seriesRepository.GetByIdAsync(id);
        if (series == null) return false;

        await _seriesRepository.DeleteAsync(series);
        return true;
    }


    public async Task<SeasonDto?> AddSeasonAsync(long seriesId, CreateSeasonDto createSeasonDto)
    {
        if (seriesId <= 0) throw new ValidationException("Invalid series id.");

        var series = await _seriesRepository.GetSeriesWithSeasonsAndEpisodesAsync(seriesId);
        if (series == null) return null;

        if (series.Seasons.Any(s => s.SeasonNumber == createSeasonDto.SeasonNumber))
            throw new ValidationException($"Season {createSeasonDto.SeasonNumber} already exists for this series.");

        var season = new Season
        {
            SeasonNumber = createSeasonDto.SeasonNumber,
            Title = createSeasonDto.Title,
            Description = createSeasonDto.Description,
            ReleaseDate = createSeasonDto.ReleaseDate,
            PosterUrl = createSeasonDto.PosterUrl,
            SeriesId = seriesId
        };

        foreach (var createEpisodeDto in createSeasonDto.Episodes)
        {
            if (season.Episodes.Any(s => s.EpisodeNumber == createEpisodeDto.EpisodeNumber))
                throw new ValidationException($"Episode {createEpisodeDto.EpisodeNumber} already exists for this season.");

            var episode = new Episode
            {
                EpisodeNumber = createEpisodeDto.EpisodeNumber,
                Title = createEpisodeDto.Title,
                AirDate = createEpisodeDto.AirDate,
                DurationMinutes = createEpisodeDto.DurationMinutes,
                Description = createEpisodeDto.Description
            };
            season.Episodes.Add(episode);
        }

        series.Seasons.Add(season);
        await _seriesRepository.UpdateAsync(series);

        return new SeasonDto
        {
            Id = season.Id,
            SeasonNumber = season.SeasonNumber,
            Title = season.Title,
            Description = season.Description,
            ReleaseDate = season.ReleaseDate,
            PosterUrl = season.PosterUrl,
            Episodes = season.Episodes.Select(ep => new EpisodeDto
            {
                Id = ep.Id,
                EpisodeNumber = ep.EpisodeNumber,
                Title = ep.Title,
                AirDate = ep.AirDate,
                DurationMinutes = ep.DurationMinutes,
                Description = ep.Description
            }).ToList()
        };
    }

    public async Task<bool> UpdateSeasonAsync(long seasonId, CreateSeasonDto createSeasonDto)
    {
        if (seasonId <= 0) throw new ValidationException("Invalid season id.");

        var season = await _seasonRepository.GetByIdWithEpisodesAsync(seasonId);
        if (season == null) return false;

        season.SeasonNumber = createSeasonDto.SeasonNumber;
        season.Title = createSeasonDto.Title;
        season.Description = createSeasonDto.Description;
        season.ReleaseDate = createSeasonDto.ReleaseDate;
        season.PosterUrl = createSeasonDto.PosterUrl;

        foreach (var episodsDto in createSeasonDto.Episodes)
        {
            var existingEpisode = season.Episodes.FirstOrDefault(e => e.EpisodeNumber == episodsDto.EpisodeNumber);

            if (existingEpisode != null)
            {
                existingEpisode.Title = episodsDto.Title;
                existingEpisode.AirDate = episodsDto.AirDate;
                existingEpisode.DurationMinutes = episodsDto.DurationMinutes;
                existingEpisode.Description = episodsDto.Description;
            }
            else
            {
                var newEpisode = new Episode
                {
                    EpisodeNumber = episodsDto.EpisodeNumber,
                    Title = episodsDto.Title,
                    AirDate = episodsDto.AirDate,
                    DurationMinutes = episodsDto.DurationMinutes,
                    Description = episodsDto.Description,
                    SeasonId = seasonId
                };
                season.Episodes.Add(newEpisode);
            }
        }

        await _seasonRepository.UpdateAsync(season);
        return true;
    }

    public async Task<bool> DeleteSeasonAsync(long seasonId)
    {
        if (seasonId <= 0) throw new ValidationException("Invalid season id.");

        var season = await _seasonRepository.GetByIdAsync(seasonId);
        if (season == null) return false;

        await _seasonRepository.DeleteAsync(season);
        return true;
    }

    public async Task<EpisodeDto?> AddEpisodeAsync(long seasonId, CreateEpisodeDto createEpisodeDto)
    {
        if (seasonId <= 0)
            throw new ValidationException("Invalid season id.");
 
        var season = await _seasonRepository.GetByIdWithEpisodesAsync(seasonId);

        if (season == null)
            return null;

        if (season.Episodes.Any(s => s.EpisodeNumber == createEpisodeDto.EpisodeNumber))
            throw new ValidationException($"Season {createEpisodeDto.EpisodeNumber} already exists for this series.");

        var episode = new Episode
        {
            EpisodeNumber = createEpisodeDto.EpisodeNumber,
            Title = createEpisodeDto.Title,
            AirDate = createEpisodeDto.AirDate,
            DurationMinutes = createEpisodeDto.DurationMinutes,
            Description = createEpisodeDto.Description,
            SeasonId = seasonId
        };

        await _episodeRepository.CreateAsync(episode);

        return new EpisodeDto
        {
            Id = episode.Id,
            EpisodeNumber = episode.EpisodeNumber,
            Title = episode.Title,
            AirDate = episode.AirDate,
            DurationMinutes = episode.DurationMinutes,
            Description = episode.Description
        };
    }

    public async Task<bool> UpdateEpisodeAsync(long episodeId, CreateEpisodeDto createEpisodeDto)
    {
        if (episodeId <= 0)
            throw new ValidationException("Invalid episode id.");

        var episode = await _episodeRepository.GetByIdAsync(episodeId);
        if (episode == null)
            return false;

        var season = await _seasonRepository.GetByIdWithEpisodesAsync(episode.SeasonId);
        if (season == null)
            return false;

        if (season.Episodes.Any(e => e.EpisodeNumber == createEpisodeDto.EpisodeNumber && e.Id != episodeId))
            throw new ValidationException($"Episode number {createEpisodeDto.EpisodeNumber} already exists in this season.");


        episode.EpisodeNumber = createEpisodeDto.EpisodeNumber;
        episode.Title = createEpisodeDto.Title;
        episode.AirDate = createEpisodeDto.AirDate;
        episode.DurationMinutes = createEpisodeDto.DurationMinutes;
        episode.Description = createEpisodeDto.Description;

        await _episodeRepository.UpdateAsync(episode);
        return true;
    }

    public async Task<bool> DeleteEpisodeAsync(long episodeId)
    {
        if (episodeId <= 0)
            throw new ValidationException("Invalid episode id.");

        var episode = await _episodeRepository.GetByIdAsync(episodeId);
        if (episode == null)
            return false;

        await _episodeRepository.DeleteAsync(episode);
        return true;
    }
}
