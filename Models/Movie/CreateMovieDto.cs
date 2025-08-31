using Microsoft.OpenApi.Any;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Movie;


/// <summary>
/// DTO for creating a movie.
/// </summary>
public class CreateMovieDto
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Genre is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Genre must be between 1 and 100 characters.")]
    public string Genre { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Director cannot exceed 100 characters.")]
    public string? Director { get; set; }

    [Required(ErrorMessage = "ReleaseDate is required.")]
    public DateTime ReleaseDate { get; set; }

    [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes.")]
    public int DurationMinutes { get; set; }

    [MaxLength(500)]
    [RegularExpression(@"^(https?:\/\/)?([\w\-]+\.)+[a-zA-Z]{2,}(\/\S*)+\.(jpg|jpeg|png|gif|webp)(\?.*)?$",
        ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    [SwaggerSchema(Description = "URL to the movie poster image")]
    public string? PosterUrl { get; set; }
}