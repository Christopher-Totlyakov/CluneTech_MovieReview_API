using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class EpisodeDto
{
    public long Id { get; set; }

    public int EpisodeNumber { get; set; }

    public string Title { get; set; } = string.Empty;
    public DateTime AirDate { get; set; }

    public int DurationMinutes { get; set; }

    public string? Description { get; set; }
}
