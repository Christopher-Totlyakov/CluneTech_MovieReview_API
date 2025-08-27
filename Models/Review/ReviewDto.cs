using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Review;

/// <summary>
/// Data Transfer Object for reviews.
/// </summary>
public class ReviewDto
{
    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int MovieId { get; set; }
}