using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

/// <summary>
/// Represents a TV series.
/// Users can review and rate the entire series.
/// </summary>
public class Series
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

    public DateTime ReleaseDate { get; set; }

    [MaxLength(ValidationConstants.UrlMaxLength)]
    [RegularExpression(ValidationConstants.ImageUrlRegex,
    ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    public string? PosterUrl { get; set; }


    [Range(ValidationConstants.RatingMin, ValidationConstants.RatingMax)]
    public double AverageRating { get; set; }

    /// <summary>
    /// Navigation: Seasons of the series
    /// </summary>
    public ICollection<Season> Seasons { get; set; } = new List<Season>();

    /// <summary>
    /// Navigation: Reviews for the whole series
    /// </summary>
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
