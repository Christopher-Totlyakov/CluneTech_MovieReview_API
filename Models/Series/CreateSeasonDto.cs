using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Series;

public class CreateSeasonDto
{

    [Range(1, 100, ErrorMessage = "Season number must be between 1 and 100.")]
    public int SeasonNumber { get; set; }


    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters.")]
    public string? Title { get; set; }

    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
    public string? Description { get; set; }


    public DateTime? ReleaseDate { get; set; }


    [MaxLength(500, ErrorMessage = "PosterUrl cannot exceed 500 characters.")]
    [RegularExpression(@"^(https?:\/\/)?([\w\-]+\.)+[a-zA-Z]{2,}(\/\S*)+\.(jpg|jpeg|png|gif|webp)(\?.*)?$",
    ErrorMessage = "PosterUrl must be a valid image URL (.jpg, .jpeg, .png, .gif, .webp).")]
    public string? PosterUrl { get; set; }

    /// <summary>
    /// Initial list of episodes.
    /// </summary>
    public List<CreateEpisodeDto> Episodes { get; set; } = new List<CreateEpisodeDto>();
}