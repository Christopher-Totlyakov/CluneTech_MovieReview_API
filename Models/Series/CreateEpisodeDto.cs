using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class CreateEpisodeDto
{

    [Range(1, 1000, ErrorMessage = "Episode number must be between 1 and 1000.")]
    public int EpisodeNumber { get; set; }


    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters.")]
    public string Title { get; set; } = string.Empty;


    [Required(ErrorMessage = "Air date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Air date must be a valid date.")]
    public DateTime AirDate { get; set; }


    [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes.")]
    public int DurationMinutes { get; set; }


    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
    public string? Description { get; set; }
}
