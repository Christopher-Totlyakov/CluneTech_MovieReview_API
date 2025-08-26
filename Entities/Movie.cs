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
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Movie title
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Short description of the movie
    /// </summary>
    [MaxLength(2000)]
    public string? Description { get; set; }

    /// <summary>
    /// Genre of the movie (Action, Drama, Comedy, etc.)
    /// </summary>
    [MaxLength(100)]
    public string Genre { get; set; } = string.Empty;

    /// <summary>
    /// Director of the movie
    /// </summary>
    [MaxLength(100)]
    public string? Director { get; set; }

    /// <summary>
    /// Release date of the movie
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Duration of the movie in minutes
    /// </summary>
    [Range(1, 600)]
    public int DurationMinutes { get; set; }

    /// <summary>
    /// Average rating calculated from reviews
    /// </summary>
    [Range(0, 10)]
    public double AverageRating { get; set; }

    /// <summary>
    /// URL to movie poster image
    /// </summary>
    [MaxLength(500)]
    public string? PosterUrl { get; set; }

    /// <summary>
    /// Collection of reviews for this movie
    /// </summary>
    public List<Review> Reviews { get; set; } = new List<Review>();
}
