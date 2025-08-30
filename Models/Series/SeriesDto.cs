using Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class SeriesDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Genre { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string? PosterUrl { get; set; }
    public double AverageRating { get; set; }

    /// <summary>
    /// List of seasons with episodes
    /// </summary>
    public List<SeasonDto> Seasons { get; set; } = new List<SeasonDto>();

    /// <summary>
    /// Reviews for the series
    /// </summary>
    public List<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
}

