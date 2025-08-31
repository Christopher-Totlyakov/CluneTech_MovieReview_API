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
    [Required(ErrorMessage = "Comment is required.")]
    [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
    public string Comment { get; set; } = string.Empty;

    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
    public int Rating { get; set; }

    [Range(1, long.MaxValue, ErrorMessage = "MovieId must be greater than 0.")]
    public long? MovieId { get; set; }

    [Range(1, long.MaxValue, ErrorMessage = "SeriesId must be greater than 0.")]
    public long SeriesId { get; set; }
}
