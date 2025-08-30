using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

/// <summary>
/// DTO for creating a new series
/// </summary>
public class CreateSeriesDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Genre { get; set; } = string.Empty;

    public DateTime ReleaseDate { get; set; }

    public string? PosterUrl { get; set; }

    /// <summary>
    /// Optional initial list of seasons with episodes
    /// </summary>
    public List<CreateSeasonDto> Seasons { get; set; } = new List<CreateSeasonDto>();
}
