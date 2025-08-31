using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class CreateSeasonDto
{
    [Range(ValidationConstants.SeasonNumberMin, ValidationConstants.SeasonNumberMax,
           ErrorMessage = "Season number must be between {1} and {2}.")]
    public int SeasonNumber { get; set; }

    [StringLength(ValidationConstants.TitleMaxLength, MinimumLength = ValidationConstants.TitleMinLength,
        ErrorMessage = "Title must be between {2} and {1} characters.")]
    public string? Title { get; set; }

    [StringLength(ValidationConstants.DescriptionMaxLength,
        ErrorMessage = "Description cannot exceed {1} characters.")]
    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [MaxLength(ValidationConstants.UrlMaxLength,
        ErrorMessage = "PosterUrl cannot exceed {1} characters.")]
    [RegularExpression(ValidationConstants.ImageUrlRegex,
        ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    public string? PosterUrl { get; set; }

    /// <summary>
    /// Initial list of episodes.
    /// </summary>
    public List<CreateEpisodeDto> Episodes { get; set; } = new List<CreateEpisodeDto>();
}