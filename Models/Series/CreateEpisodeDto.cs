using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class CreateEpisodeDto
{
    [Range(ValidationConstants.EpisodeNumberMin, ValidationConstants.EpisodeNumberMax,
            ErrorMessage = "Episode number must be between {1} and {2}.")]
    public int EpisodeNumber { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(ValidationConstants.TitleMaxLength, MinimumLength = ValidationConstants.TitleMinLength,
        ErrorMessage = "Title must be between {2} and {1} characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Air date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Air date must be a valid date.")]
    public DateTime AirDate { get; set; }

    [Range(ValidationConstants.DurationMin, ValidationConstants.DurationMax,
        ErrorMessage = "Duration must be between {1} and {2} minutes.")]
    public int DurationMinutes { get; set; }

    [StringLength(ValidationConstants.DescriptionMaxLength,
        ErrorMessage = "Description cannot exceed {1} characters.")]
    public string? Description { get; set; }
}
