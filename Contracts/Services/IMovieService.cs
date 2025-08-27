using Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services;

/// <summary>
/// Service contract for movies.
/// </summary>
public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    Task<MovieDto?> GetMovieByIdAsync(int id);
    Task<MovieDto> CreateMovieAsync(CreateMovieDto dto);
    Task<bool> UpdateMovieAsync(int id, CreateMovieDto dto);
    Task<bool> DeleteMovieAsync(int id);
}
