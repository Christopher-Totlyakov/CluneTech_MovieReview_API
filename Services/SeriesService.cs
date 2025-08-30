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
        var seriesList = await _seriesRepository.GetAllAsync();
        return seriesList.Select(s => new SeriesDto
        {
            Id = s.Id,
            Title = s.Title,
            Description = s.Description,
            Genre = s.Genre,
            ReleaseDate = s.ReleaseDate,
            AverageRating = s.AverageRating
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
            Reviews = series.Reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Comment = r.Comment,
                Rating = r.Rating,
                UserName = r.User?.UserName ?? "Unknown",
                SeriesId = r.SeriesId
            }).ToList(),
            Seasons = series.Seasons.Select(season => new SeasonDto
            {
                Id = season.Id,
                SeasonNumber = season.SeasonNumber,
                Episodes = season.Episodes.Select(ep => new EpisodeDto
                {
                    Id = ep.Id,
                    EpisodeNumber = ep.EpisodeNumber,
                    Title = ep.Title,
                    AirDate = ep.AirDate,
                    DurationMinutes = ep.DurationMinutes,
                    Description = ep.Description
                }).ToList()
            }).ToList()
        };
    }

    public async Task<SeriesDto> CreateSeriesAsync(CreateSeriesDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ValidationException("Title is required.");

        if (dto.Title.Length > 200)
            throw new ValidationException("Title cannot exceed 200 characters.");

        if (!string.IsNullOrWhiteSpace(dto.Description) && dto.Description.Length > 2000)
            throw new ValidationException("Description cannot exceed 2000 characters.");

        if (string.IsNullOrWhiteSpace(dto.Genre))
            throw new ValidationException("Genre is required.");

        if (dto.ReleaseDate == default)
            throw new ValidationException("Release date is required.");

        var series = new Series
        {
            Title = dto.Title,
            Description = dto.Description,
            Genre = dto.Genre,
            ReleaseDate = dto.ReleaseDate,
            PosterUrl = dto.PosterUrl
        };

        foreach (var seasonDto in dto.Seasons)
        {
            if (seasonDto.SeasonNumber < 1)
                throw new ValidationException("Season number must be at least 1.");

            var season = new Season
            {
                SeasonNumber = seasonDto.SeasonNumber
            };

            foreach (var epDto in seasonDto.Episodes)
            {
                if (epDto.EpisodeNumber < 1)
                    throw new ValidationException("Episode number must be at least 1.");

                if (epDto.DurationMinutes < 1)
                    throw new ValidationException("Episode duration must be at least 1 minute.");

                var episode = new Episode
                {
                    EpisodeNumber = epDto.EpisodeNumber,
                    Title = epDto.Title,
                    AirDate = epDto.AirDate,
                    DurationMinutes = epDto.DurationMinutes,
                    Description = epDto.Description
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
            AverageRating = series.AverageRating
        };
    }

    public async Task<bool> UpdateSeriesAsync(long id, CreateSeriesDto dto)
    {
        if (id <= 0)
            throw new ValidationException("Invalid series id.");

        var series = await _seriesRepository.GetByIdAsync(id);
        if (series == null) return false;

        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ValidationException("Title is required.");

        if (dto.Title.Length > 200)
            throw new ValidationException("Title cannot exceed 200 characters.");

        if (!string.IsNullOrWhiteSpace(dto.Description) && dto.Description.Length > 2000)
            throw new ValidationException("Description cannot exceed 2000 characters.");

        if (string.IsNullOrWhiteSpace(dto.Genre))
            throw new ValidationException("Genre is required.");

        series.Title = dto.Title;
        series.Description = dto.Description;
        series.Genre = dto.Genre;
        series.ReleaseDate = dto.ReleaseDate;
        series.PosterUrl = dto.PosterUrl;

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


    public async Task<SeasonDto?> AddSeasonAsync(long seriesId, CreateSeasonDto dto)
    {
        if (seriesId <= 0) throw new ValidationException("Invalid series id.");
        if (dto.SeasonNumber < 1) throw new ValidationException("Season number must be >= 1.");

        var series = await _seriesRepository.GetSeriesWithSeasonsAndEpisodesAsync(seriesId);
        if (series == null) return null;

        if (series.Seasons.Any(s => s.SeasonNumber == dto.SeasonNumber))
            throw new ValidationException($"Season {dto.SeasonNumber} already exists for this series.");

        var season = new Season
        {
            SeasonNumber = dto.SeasonNumber,
            SeriesId = seriesId
        };

        series.Seasons.Add(season);
        await _seriesRepository.UpdateAsync(series);

        return new SeasonDto
        {
            Id = season.Id,
            SeasonNumber = season.SeasonNumber
        };
    }

    public async Task<bool> UpdateSeasonAsync(long seasonId, CreateSeasonDto dto)
    {
        if (seasonId <= 0) throw new ValidationException("Invalid season id.");
        if (dto.SeasonNumber < 1) throw new ValidationException("Season number must be >= 1.");

        var season = await _seasonRepository.GetByIdAsync(seasonId);
        if (season == null) return false;

        season.SeasonNumber = dto.SeasonNumber;
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

    public async Task<EpisodeDto?> AddEpisodeAsync(long seasonId, CreateEpisodeDto dto)
    {
        if (seasonId <= 0)
            throw new ValidationException("Invalid season id.");
        if (dto.EpisodeNumber < 1)
            throw new ValidationException("Episode number must be >= 1.");
        if (dto.DurationMinutes < 1)
            throw new ValidationException("Episode duration must be >= 1.");

 
        var season = await _seasonRepository.GetByIdAsync(seasonId);

        if (season == null)
            return null;

        if (season.Episodes.Any(s => s.EpisodeNumber == dto.EpisodeNumber))
            throw new ValidationException($"Season {dto.EpisodeNumber} already exists for this series.");

        var episode = new Episode
        {
            EpisodeNumber = dto.EpisodeNumber,
            Title = dto.Title,
            AirDate = dto.AirDate,
            DurationMinutes = dto.DurationMinutes,
            Description = dto.Description,
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

    public async Task<bool> UpdateEpisodeAsync(long episodeId, CreateEpisodeDto dto)
    {
        if (episodeId <= 0)
            throw new ValidationException("Invalid episode id.");
        if (dto.EpisodeNumber < 1)
            throw new ValidationException("Episode number must be >= 1.");
        if (dto.DurationMinutes < 1)
            throw new ValidationException("Episode duration must be >= 1.");

        var episode = await _episodeRepository.GetByIdAsync(episodeId);
        if (episode == null)
            return false;

        episode.EpisodeNumber = dto.EpisodeNumber;
        episode.Title = dto.Title;
        episode.AirDate = dto.AirDate;
        episode.DurationMinutes = dto.DurationMinutes;
        episode.Description = dto.Description;

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
