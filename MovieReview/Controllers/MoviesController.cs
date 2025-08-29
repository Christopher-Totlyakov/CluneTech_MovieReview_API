using Contracts.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Movie;

namespace MovieReview.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _movieService.GetAllMoviesAsync();
        return Ok(movies);
    }

    [HttpGet("getBy/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateMovieDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var movie = await _movieService.CreateMovieAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateMovieDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _movieService.UpdateMovieAsync(id, dto);
        if (!result) return NotFound();
        return NoContent();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _movieService.DeleteMovieAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}