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

    [Range(ValidationConstants.SeasonNumberMin, ValidationConstants.SeasonNumberMax)]
    public int SeasonNumber { get; set; }

    [MaxLength(ValidationConstants.TitleMaxLength)]
    public string? Title { get; set; }

    [MaxLength(ValidationConstants.DescriptionMaxLength)]
    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [MaxLength(ValidationConstants.UrlMaxLength)]
    [RegularExpression(ValidationConstants.ImageUrlRegex,
        ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    public string? PosterUrl { get; set; }

    [ForeignKey("Series")]
    public long SeriesId { get; set; }
    public Series Series { get; set; }

    public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
}