using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Review;

public class UpdateReviewDto
{
    [Required(ErrorMessage = "Comment is required.")]
    [StringLength(ValidationConstants.ReviewCommentMaxLength,
        ErrorMessage = "Comment cannot exceed {1} characters.")]
    public string Comment { get; set; } = string.Empty;

    [Range(ValidationConstants.ReviewRatingMin, ValidationConstants.ReviewRatingMax,
        ErrorMessage = "Rating must be between {1} and {2}.")]
    public int Rating { get; set; }
}
