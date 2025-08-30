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
    public List<EpisodeDto> Episodes { get; set; } = new List<EpisodeDto>();
}
