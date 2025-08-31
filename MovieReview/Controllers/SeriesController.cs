using Contracts.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Series;

namespace MovieReview.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeriesController : ControllerBase
{
    private readonly ISeriesService _seriesService;

    public SeriesController(ISeriesService seriesService)
    {
        _seriesService = seriesService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var seriesList = await _seriesService.GetAllSeriesAsync();
        return Ok(seriesList);
    }

    [HttpGet("getBy/{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var series = await _seriesService.GetSeriesByIdAsync(id);
        if (series == null) return NotFound();
        return Ok(series);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateSeriesDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var series = await _seriesService.CreateSeriesAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = series.Id }, series);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateSeriesDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _seriesService.UpdateSeriesAsync(id, dto);
        if (!result) return NotFound();

        return NoContent();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _seriesService.DeleteSeriesAsync(id);
        if (!result) return NotFound();

        return NoContent();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("{seriesId}/seasons/add")]
    public async Task<IActionResult> AddSeason(long seriesId, [FromBody] CreateSeasonDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var season = await _seriesService.AddSeasonAsync(seriesId, dto);
        if (season == null) return NotFound();
        return Ok(season);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut("seasons/update/{seasonId}")]
    public async Task<IActionResult> UpdateSeason(long seasonId, [FromBody] CreateSeasonDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _seriesService.UpdateSeasonAsync(seasonId, dto);
        if (!result) return NotFound();
        return NoContent();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpDelete("seasons/delete/{seasonId}")]
    public async Task<IActionResult> DeleteSeason(long seasonId)
    {
        var result = await _seriesService.DeleteSeasonAsync(seasonId);
        if (!result) return NotFound();
        return NoContent();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("seasons/{seasonId}/episodes/add")]
    public async Task<IActionResult> AddEpisode(long seasonId, [FromBody] CreateEpisodeDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var episode = await _seriesService.AddEpisodeAsync(seasonId, dto);
        if (episode == null) return NotFound();
        return Ok(episode);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut("episodes/update/{episodeId}")]
    public async Task<IActionResult> UpdateEpisode(long episodeId, [FromBody] CreateEpisodeDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _seriesService.UpdateEpisodeAsync(episodeId, dto);
        if (!result) return NotFound();
        return NoContent();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpDelete("episodes/delete/{episodeId}")]
    public async Task<IActionResult> DeleteEpisode(long episodeId)
    {
        var result = await _seriesService.DeleteEpisodeAsync(episodeId);
        if (!result) return NotFound();
        return NoContent();
    }
}
