using Entities;
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
    [StringLength(ValidationConstants.TitleMaxLength, MinimumLength = ValidationConstants.TitleMinLength,
        ErrorMessage = "Title must be between {2} and {1} characters.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(ValidationConstants.DescriptionMaxLength,
    ErrorMessage = "Description cannot exceed {1} characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Genre is required.")]
    [StringLength(ValidationConstants.GenreMaxLength, MinimumLength = ValidationConstants.TitleMinLength,
        ErrorMessage = "Genre must be between {2} and {1} characters.")]
    public string Genre { get; set; } = string.Empty;

    [StringLength(ValidationConstants.DirectorMaxLength,
    ErrorMessage = "Director cannot exceed {1} characters.")]
    public string? Director { get; set; }

    [Required(ErrorMessage = "ReleaseDate is required.")]
    public DateTime ReleaseDate { get; set; }

    [Range(ValidationConstants.DurationMin, ValidationConstants.DurationMax,
    ErrorMessage = "Duration must be between {1} and {2} minutes.")]
    public int DurationMinutes { get; set; }

    [MaxLength(ValidationConstants.UrlMaxLength)]
    [RegularExpression(ValidationConstants.ImageUrlRegex,
        ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    [SwaggerSchema(Description = "URL to the movie poster image")]
    public string? PosterUrl { get; set; }
}