using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class SeasonDto
{
    public long Id { get; set; }

    /// <summary>
    /// Номер на сезона (напр. 1, 2, 3...)
    /// </summary>
    public int SeasonNumber { get; set; }

    /// <summary>
    /// Заглавие на сезона (ако сериалът има специално име за него)
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Описание/сюжет на сезона
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата на първо излъчване на сезона
    /// </summary>
    public DateTime? ReleaseDate { get; set; }

    /// <summary>
    /// URL към постер/корица на сезона
    /// </summary>
    public string? PosterUrl { get; set; }

    ///// <summary>
    ///// Средна оценка на сезона (изчислена от ревютата на епизодите или отделно)
    ///// </summary>
    //public double AverageRating { get; set; }

    /// <summary>
    /// Списък с епизодите
    /// </summary>
    public List<EpisodeDto> Episodes { get; set; } = new List<EpisodeDto>();
}
