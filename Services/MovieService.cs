using Contracts.Repository;
using Contracts.Services;
using Entities;
using Models.Movie;
using Models.Review;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
    {
        var movies = await _movieRepository.GetAllAsync();
        return movies.Select(m => new MovieDto
        {
            Id = m.Id,
            Title = m.Title,
            Description = m.Description,
            Genre = m.Genre,
            Director = m.Director,
            ReleaseDate = m.ReleaseDate,
            DurationMinutes = m.DurationMinutes,
            AverageRating = m.AverageRating,
            PosterUrl = m.PosterUrl
        });
    }

    public async Task<MovieDto?> GetMovieByIdAsync(int id)
    {
        if (id <= 0)
            throw new ValidationException("Invalid movie id.");

        var movie = await _movieRepository.GetMovieWithReviewsAsync(id);
        if (movie == null) return null;

        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Genre = movie.Genre,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
            DurationMinutes = movie.DurationMinutes,
            AverageRating = movie.AverageRating,
            PosterUrl = movie.PosterUrl,
            Reviews = movie.Reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Comment = r.Comment,
                Rating = r.Rating,
                UserName = r.User?.UserName ?? "Unknown",
                MovieId = r.MovieId
            }).ToList()
        };
    }

    public async Task<MovieDto> CreateMovieAsync(CreateMovieDto dto)
    {
        var movie = new Movie
        {
            Title = dto.Title,
            Description = dto.Description,
            Genre = dto.Genre,
            Director = dto.Director,
            ReleaseDate = dto.ReleaseDate,
            DurationMinutes = dto.DurationMinutes,
            PosterUrl = dto.PosterUrl
        };


        await _movieRepository.CreateAsync(movie);

        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Genre = movie.Genre,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
            DurationMinutes = movie.DurationMinutes,
            PosterUrl = movie.PosterUrl
        };
    }

    public async Task<bool> UpdateMovieAsync(long id, CreateMovieDto dto)
    {
        if (id <= 0)
            throw new ValidationException("Invalid movie id.");

        var movie = await _movieRepository.GetByIdAsync(id);
        if (movie == null) return false;

        movie.Title = dto.Title;
        movie.Description = dto.Description;
        movie.Genre = dto.Genre;
        movie.Director = dto.Director;
        movie.ReleaseDate = dto.ReleaseDate;
        movie.DurationMinutes = dto.DurationMinutes;
        movie.PosterUrl = dto.PosterUrl;

        await _movieRepository.UpdateAsync(movie);
        return true;
    }

    public async Task<bool> DeleteMovieAsync(long id)
    {
        if (id <= 0)
            throw new ValidationException("Invalid movie id.");

        var movie = await _movieRepository.GetByIdAsync(id);
        if (movie == null) return false;

        await _movieRepository.DeleteAsync(movie);
        return true;
    }
}
