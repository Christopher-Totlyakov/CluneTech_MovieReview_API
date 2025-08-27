using Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Movie;

/// <summary>
/// Data Transfer Object for movies.
/// </summary>
public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }

    public IEnumerable<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
}
