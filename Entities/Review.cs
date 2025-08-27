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
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Review text
    /// </summary>
    [Required]
    [MaxLength(2000)]
    public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// Rating (1–10)
    /// </summary>
    [Range(1, 10)]
    public int Rating { get; set; }

    /// <summary>
    /// Date when review was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Date when review was last updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Foreign Key → Movie
    /// </summary>
    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }

    /// <summary>
    /// Foreign Key → User
    /// </summary>
    [ForeignKey("User")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
