using Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series
{
    public class UpdateSeriesDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(ValidationConstants.TitleMaxLength, MinimumLength = ValidationConstants.TitleMinLength,
            ErrorMessage = "Title must be between {2} and {1} characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(ValidationConstants.DescriptionMaxLength,
            ErrorMessage = "Description cannot exceed {1} characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(ValidationConstants.GenreMaxLength, MinimumLength = ValidationConstants.TitleMinLength,
            ErrorMessage = "Genre must be between {2} and {1} characters.")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "ReleaseDate is required.")]
        public DateTime ReleaseDate { get; set; }

        [MaxLength(ValidationConstants.UrlMaxLength,
            ErrorMessage = "PosterUrl cannot exceed {1} characters.")]
        [RegularExpression(ValidationConstants.ImageUrlRegex,
            ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
        [SwaggerSchema(Description = "URL to the series poster image")]
        public string? PosterUrl { get; set; }
    }
}
