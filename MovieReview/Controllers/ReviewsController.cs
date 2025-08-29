using Contracts.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

    [HttpGet("movie/{movieId}/reviews")]
    public async Task<IActionResult> GetReviewsForMovie(int movieId)
    {
        var reviews = await _reviewService.GetReviewsForMovieAsync(movieId);
        return Ok(reviews);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateReviewDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized();

        var userName = User.Identity?.Name;

        var review = await _reviewService.CreateReviewAsync(userId, userName, dto);
        return Ok(review);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut("update/{reviewId}")]
    public async Task<IActionResult> Update(int reviewId, [FromBody] UpdateReviewDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized();

        var userName = User.Identity?.Name;

        var updatedReview = await _reviewService.UpdateReviewAsync(userId, userName, reviewId, dto);
        return Ok(updatedReview);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpDelete("delete/{reviewId}")]
    public async Task<IActionResult> Delete(int reviewId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized();

        var success = await _reviewService.DeleteReviewAsync(userId, reviewId);
        if (!success) return NotFound();

        return NoContent();
    }

}
