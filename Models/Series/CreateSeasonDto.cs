using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class CreateSeasonDto
{
    public int SeasonNumber { get; set; }
    public List<CreateEpisodeDto> Episodes { get; set; } = new List<CreateEpisodeDto>();
}