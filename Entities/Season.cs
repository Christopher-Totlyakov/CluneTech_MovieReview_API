using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

/// <summary>
/// Represents a season of a series.
/// </summary>
public class Season
{
    [Key]
    public long Id { get; set; }

    [Range(1, 100)]
    public int SeasonNumber { get; set; }

    [MaxLength(200)]
    public string? Title { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [MaxLength(500)]
    [RegularExpression(@"^(https?:\/\/)?([\w\-]+\.)+[a-zA-Z]{2,}(\/\S*)+\.(jpg|jpeg|png|gif|webp)(\?.*)?$",
    ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    public string? PosterUrl { get; set; }

    [ForeignKey("Series")]
    public long SeriesId { get; set; }
    public Series Series { get; set; }

    public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
}