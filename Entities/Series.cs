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
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Description { get; set; }

    [MaxLength(100)]
    public string Genre { get; set; } = string.Empty;

    public DateTime ReleaseDate { get; set; }

    [MaxLength(500)]
    [RegularExpression(@"^(https?:\/\/)?([\w\-]+\.)+[a-zA-Z]{2,}(\/\S*)+\.(jpg|jpeg|png|gif|webp)$",
    ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    public string? PosterUrl { get; set; }

    /// <summary>
    /// Average rating calculated from reviews
    /// </summary>
    [Range(0, 10)]
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
