using Contracts.Repository;
using Contracts.Services;
using Entities;
using Microsoft.AspNetCore.Identity;
using Models.Review;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<ReviewDto>> GetReviewsForMovieAsync(int movieId)
    {
        if (movieId <= 0)
            throw new ValidationException("Invalid movie id.");

        var reviews = await _reviewRepository.GetReviewsForMovieAsync(movieId);
        return reviews.Select(r => new ReviewDto
        {
            Id = r.Id,
            Comment = r.Comment,
            Rating = r.Rating,
            UserName = r.User?.UserName ?? "Unknown",
            MovieId = r.MovieId
        });
    }

    public async Task<ReviewDto> CreateReviewAsync(string userId, string userName, CreateReviewDto dto)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ValidationException("User is required.");

        var review = new Review
        {
            Comment = dto.Comment,
            Rating = dto.Rating,
            MovieId = dto.MovieId,
            UserId = userId
        };

        await _reviewRepository.CreateAsync(review);

        return new ReviewDto
        {
            Id = review.Id,
            Comment = review.Comment,
            Rating = review.Rating,
            UserName = userName ?? "Unknown",
            MovieId = review.MovieId
        };
    }

    public async Task<ReviewDto> UpdateReviewAsync(string userId, string userName, long reviewId, UpdateReviewDto dto)
    {
        if (reviewId <= 0)
            throw new ValidationException("Invalid review id.");

        var review = await _reviewRepository.GetByIdAsync(reviewId);
        if (review == null)
            throw new ValidationException("Review not found.");

        if (review.UserId != userId)
            throw new UnauthorizedAccessException("You can only update your own reviews.");

        review.Comment = dto.Comment;
        review.Rating = dto.Rating;
        review.UpdatedAt = DateTime.UtcNow;

        await _reviewRepository.UpdateAsync(review);

        return new ReviewDto
        {
            Id = review.Id,
            Comment = review.Comment,
            Rating = review.Rating,
            UserName = userName ?? "Unknown",
            MovieId = review.MovieId
        };
    }

    public async Task<bool> DeleteReviewAsync(string userId, long reviewId)
    {
        var review = await _reviewRepository.GetByIdAsync(reviewId);
        if (review == null)
            throw new ValidationException("Review not found.");

        if (review.UserId != userId)
            throw new UnauthorizedAccessException("You can only delete your own reviews.");

        await _reviewRepository.DeleteAsync(review);
        return true;
    }

}
