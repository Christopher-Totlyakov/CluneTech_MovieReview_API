using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

/// <summary>
/// Represents a review that a user writes for a movie.
/// Includes text and rating.
/// </summary>
public class Review
{

    [Key]
    public long Id { get; set; }


    [Required]
    [MaxLength(ValidationConstants.DescriptionMaxLength)]
    public string Comment { get; set; } = string.Empty;

    [Range(ValidationConstants.RatingMin, ValidationConstants.RatingMax)]
    public int Rating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("Movie")]
    public long? MovieId { get; set; }
    public Movie? Movie { get; set; }


    [ForeignKey("Series")]
    public long? SeriesId { get; set; }
    public Series? Series { get; set; }


    [ForeignKey("User")]
    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }
}
