using Swashbuckle.AspNetCore.Annotations;
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
public class CreateSeriesDto : UpdateSeriesDto
{
    /// <summary>
    /// Optional initial list of seasons with episodes
    /// </summary>
    public List<CreateSeasonDto> Seasons { get; set; } = new List<CreateSeasonDto>();
}

