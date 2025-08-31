using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

/// <summary>
/// Represents a movie in the system.
/// Users can review and rate movies.
/// </summary>
public class Movie
{

    [Key]
    public long Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TitleMaxLength)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(ValidationConstants.DescriptionMaxLength)]
    public string? Description { get; set; }

    [MaxLength(ValidationConstants.GenreMaxLength)]
    public string Genre { get; set; } = string.Empty;

    [MaxLength(ValidationConstants.DirectorMaxLength)]
    public string? Director { get; set; }

    public DateTime ReleaseDate { get; set; }

    [Range(ValidationConstants.DurationMin, ValidationConstants.DurationMax)]
    public int DurationMinutes { get; set; }

    [Range(ValidationConstants.RatingMin, ValidationConstants.RatingMax)]
    public double AverageRating { get; set; }

    [MaxLength(ValidationConstants.UrlMaxLength)]
    [RegularExpression(ValidationConstants.ImageUrlRegex,
    ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    public string? PosterUrl { get; set; }

    /// <summary>
    /// Collection of reviews for this movie
    /// </summary>
    public List<Review> Reviews { get; set; } = new List<Review>();
}
