using Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Review;
using System.Security.Claims;

namespace MovieReview.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("movie/{movieId}")]
    public async Task<IActionResult> GetReviewsForMovie(int movieId)
    {
        var reviews = await _reviewService.GetReviewsForMovieAsync(movieId);
        return Ok(reviews);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReviewDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized();

        var review = await _reviewService.CreateReviewAsync(userId, dto);
        return Ok(review);
    }
}
