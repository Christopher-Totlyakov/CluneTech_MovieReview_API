using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class CreateEpisodeDto
{
    public int EpisodeNumber { get; set; }
    public string Title { get; set; } = string.Empty;

    public DateTime AirDate { get; set; }

    public int DurationMinutes { get; set; }

    public string? Description { get; set; }
}
