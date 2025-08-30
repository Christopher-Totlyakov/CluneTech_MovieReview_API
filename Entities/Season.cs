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

    [ForeignKey("Series")]
    public long SeriesId { get; set; }
    public Series Series { get; set; }

    public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
}