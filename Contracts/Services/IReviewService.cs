using Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services;

/// <summary>
/// Service contract for managing <see cref="Review"/> entities.
/// </summary>
public interface IReviewService
{
    /// <summary>
    /// Retrieves all reviews associated with a specific movie.
    /// </summary>
    /// <param name="movieId">The unique identifier of the movie.</param>
    /// <returns>A collection of <see cref="ReviewDto"/> objects.</returns>
    Task<IEnumerable<ReviewDto>> GetReviewsForMovieAsync(int movieId);

    /// <summary>
    /// Creates a new review for a movie.
    /// </summary>
    /// <param name="userId">The unique identifier of the user creating the review.</param>
    /// <param name="userName">The username of the user creating the review.</param>
    /// <param name="dto">The details of the review to create.</param>
    /// <returns>The created <see cref="ReviewDto"/>.</returns>
    Task<ReviewDto> CreateReviewAsync(string userId, string userName, CreateReviewDto dto);

    /// <summary>
    /// Updates an existing review.
    /// </summary>
    /// <param name="userId">The unique identifier of the user updating the review.</param>
    /// <param name="userName">The username of the user updating the review.</param>
    /// <param name="reviewId">The unique identifier of the review to update.</param>
    /// <param name="dto">The updated review details.</param>
    /// <returns>The updated <see cref="ReviewDto"/>.</returns>
    Task<ReviewDto> UpdateReviewAsync(string userId, string userName, long reviewId, UpdateReviewDto dto);

    /// <summary>
    /// Deletes a review.
    /// </summary>
    /// <param name="userId">The unique identifier of the user requesting the deletion.</param>
    /// <param name="reviewId">The unique identifier of the review to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteReviewAsync(string userId, long reviewId);
}
