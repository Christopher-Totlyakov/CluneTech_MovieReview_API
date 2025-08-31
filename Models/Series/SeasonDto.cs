using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class SeasonDto
{
    public long Id { get; set; }
    public int SeasonNumber { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }
    public string? PosterUrl { get; set; }

    public double AverageRating { get; set; }

    public List<EpisodeDto> Episodes { get; set; } = new List<EpisodeDto>();
}
