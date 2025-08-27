using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Review;


/// <summary>
/// DTO for creating a review.
/// </summary>
public class CreateReviewDto
{
    public string Comment { get; set; } = string.Empty;

    public int Rating { get; set; }

    public int MovieId { get; set; }
}
