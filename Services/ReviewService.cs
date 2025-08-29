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

        if (string.IsNullOrWhiteSpace(dto.Comment))
            throw new ValidationException("Comment is required.");

        if (dto.Comment.Length > 1000)
            throw new ValidationException("Comment cannot exceed 1000 characters.");

        if (dto.Rating < 1 || dto.Rating > 10)
            throw new ValidationException("Rating must be between 1 and 10.");

        if (dto.MovieId <= 0)
            throw new ValidationException("Invalid movie id.");

        var review = new Review
        {
            Comment = dto.Comment,
            Rating = dto.Rating,
            MovieId = dto.MovieId,
            UserId = userId
        };

        return new ReviewDto
        {
            Id = review.Id,
            Comment = review.Comment,
            Rating = review.Rating,
            UserName = userName ?? "Unknown",
            MovieId = review.MovieId
        };
    }
}
