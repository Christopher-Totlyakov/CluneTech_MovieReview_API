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
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Description { get; set; }

    [MaxLength(100)]
    public string Genre { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Director { get; set; }

    public DateTime ReleaseDate { get; set; }

    [Range(1, 600)]
    public int DurationMinutes { get; set; }

    [Range(0, 10)]
    public double AverageRating { get; set; }

    [MaxLength(500)]
    [RegularExpression(@"^(https?:\/\/)?([\w\-]+\.)+[a-zA-Z]{2,}(\/\S*)+\.(jpg|jpeg|png|gif|webp)(\?.*)?$",
    ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    public string? PosterUrl { get; set; }

    /// <summary>
    /// Collection of reviews for this movie
    /// </summary>
    public List<Review> Reviews { get; set; } = new List<Review>();
}
