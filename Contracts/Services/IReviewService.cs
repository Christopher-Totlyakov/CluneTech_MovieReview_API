using Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services;

/// <summary>
/// Service contract for reviews.
/// </summary>
public interface IReviewService
{
    Task<IEnumerable<ReviewDto>> GetReviewsForMovieAsync(int movieId);
    Task<ReviewDto> CreateReviewAsync(string userId, string userName, CreateReviewDto dto);
    Task<ReviewDto> UpdateReviewAsync(string userId, string userName, long reviewId, UpdateReviewDto dto);
}
