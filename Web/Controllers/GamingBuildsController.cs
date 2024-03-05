using Application.Interfaces;
using Application.Services;
using DTOS.GamingBuildsDTOs;
using Microsoft.AspNetCore.Mvc;
using UPG.Core.Filters;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamingBuildsController : ControllerBase
{
    private readonly IGamingBuildsService _gamingBuildsService;

    public GamingBuildsController(IGamingBuildsService gamingBuildsService)
    {
        _gamingBuildsService = gamingBuildsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetGamingBuilds()
    {
        var gamingBuilds = await _gamingBuildsService.GetGamingBuildsAsync();
        return Ok(gamingBuilds);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGamingBuildsById(int id)
    {
        try
        {
            var gamingBuilds = await _gamingBuildsService.GetGamingBuildsByIdAsync(id);
            return Ok(gamingBuilds);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddGamingBuilds(AddGamingBuildsDTO dto)
    {
        await _gamingBuildsService.AddGamingBuildsAsync(dto);
        return Ok("GamingBuilds added successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGamingBuilds(UpdateGamingBuildsDTO dto)
    {
        try
        {
            await _gamingBuildsService.UpdateGamingBuildsAsync(dto);
            return Ok("GamingBuilds updated successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGamingBuilds(int id)
    {
        try
        {
            await _gamingBuildsService.DeleteGamingBuildsAsync(id);
            return Ok("GamingBuilds deleted successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] GamingBuildsFilter filter)
    {
        try
        {
            var dto = await _gamingBuildsService.Filter(filter);
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
