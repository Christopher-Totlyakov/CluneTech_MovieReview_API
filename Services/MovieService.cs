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
            ReleaseDate = m.ReleaseDate
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
            ReleaseDate = movie.ReleaseDate,
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

        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ValidationException("Title is required.");

        if (dto.Title.Length > 200)
            throw new ValidationException("Title cannot exceed 200 characters.");

        if (!string.IsNullOrWhiteSpace(dto.Description) && dto.Description.Length > 1000)
            throw new ValidationException("Description cannot exceed 1000 characters.");

        if (dto.ReleaseDate == default)
            throw new ValidationException("Release date is required.");

        if (dto.ReleaseDate < new DateTime(1900, 1, 1))
            throw new ValidationException("Release date is too far in the past.");

        var movie = new Movie
        {
            Title = dto.Title,
            Description = dto.Description,
            ReleaseDate = dto.ReleaseDate
        };

        await _movieRepository.CreateAsync(movie);

        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            ReleaseDate = movie.ReleaseDate
        };
    }

    public async Task<bool> UpdateMovieAsync(long id, CreateMovieDto dto)
    {
        if (id <= 0)
            throw new ValidationException("Invalid movie id.");

        var movie = await _movieRepository.GetByIdAsync(id);
        if (movie == null) return false;


        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ValidationException("Title is required.");

        if (dto.Title.Length > 200)
            throw new ValidationException("Title cannot exceed 200 characters.");

        if (!string.IsNullOrWhiteSpace(dto.Description) && dto.Description.Length > 1000)
            throw new ValidationException("Description cannot exceed 1000 characters.");

        movie.Title = dto.Title;
        movie.Description = dto.Description;
        movie.ReleaseDate = dto.ReleaseDate;

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
