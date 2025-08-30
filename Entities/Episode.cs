using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

/// <summary>
/// Represents an episode in a season.
/// </summary>
public class Episode
{
    [Key]
    public long Id { get; set; }

    [Range(1, 1000)]
    public int EpisodeNumber { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public DateTime AirDate { get; set; }

    [Range(1, 600)]
    public int DurationMinutes { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    [ForeignKey("Season")]
    public long SeasonId { get; set; }
    public Season Season { get; set; }
}
