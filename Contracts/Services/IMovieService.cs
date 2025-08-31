using Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services;

/// <summary>
/// Service contract for managing <see cref="Movie"/> entities.
/// </summary>
public interface IMovieService
{
    /// <summary>
    /// Retrieves all movies.
    /// </summary>
    /// <returns>A collection of <see cref="MovieDto"/> objects.</returns>
    Task<IEnumerable<MovieDto>> GetAllMoviesAsync();

    /// <summary>
    /// Retrieves a movie by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the movie.</param>
    /// <returns>The <see cref="MovieDto"/> if found; otherwise, null.</returns>
    Task<MovieDto?> GetMovieByIdAsync(int id);

    /// <summary>
    /// Creates a new movie with the specified details.
    /// </summary>
    /// <param name="dto">The details of the movie to create.</param>
    /// <returns>The created <see cref="MovieDto"/>.</returns>
    Task<MovieDto> CreateMovieAsync(CreateMovieDto dto);

    /// <summary>
    /// Updates an existing movie by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the movie to update.</param>
    /// <param name="dto">The updated movie details.</param>
    /// <returns>True if the update was successful; otherwise, false.</returns>
    Task<bool> UpdateMovieAsync(long id, CreateMovieDto dto);

    /// <summary>
    /// Deletes a movie by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the movie to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteMovieAsync(long id);
}
