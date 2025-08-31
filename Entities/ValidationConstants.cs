using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;


/// <summary>
/// Centralized constants for validation attributes.
/// </summary>
public static class ValidationConstants
{

    public const int TitleMaxLength = 200;
    public const int TitleMinLength = 1;


    public const int DescriptionMaxLength = 2000;


    public const int GenreMaxLength = 100;
    public const int DirectorMaxLength = 100;


    public const int UrlMaxLength = 500;
    public const string ImageUrlRegex =
        @"^(https?:\/\/)?([\w\-]+\.)+[a-zA-Z]{2,}(\/\S*)+\.(jpg|jpeg|png|gif|webp)(\?.*)?$";


    public const int RatingMin = 0;
    public const int RatingMax = 10;


    public const int DurationMin = 1;
    public const int DurationMax = 600;


    public const int EpisodeNumberMin = 1;
    public const int EpisodeNumberMax = 1000;


    public const int SeasonNumberMin = 1;
    public const int SeasonNumberMax = 100;


    public const int UserNameMinLength = 3;
    public const int UserNameMaxLength = 50;

    public const int PasswordMinLength = 6;
    public const int PasswordMaxLength = 100;


    public const int ReviewCommentMaxLength = 1000;
    public const int ReviewRatingMin = 1;
    public const int ReviewRatingMax = 10;
    public const long IdMin = 1;
}