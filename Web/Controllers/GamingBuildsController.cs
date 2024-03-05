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
    public async Task<IActionResult> GetArmchairById(int id)
    {
        try
        {
            var armchair = await _gamingBuildsService.GetGamingBuildsByIdAsync(id);
            return Ok(armchair);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddArmchair(AddGamingBuildsDTO dto)
    {
        await _gamingBuildsService.AddGamingBuildsAsync(dto);
        return Ok("Armchair added successfully.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArmchair(int id, UpdateGamingBuildsDTO dto)
    {
        try
        {
            dto.ID = id; // Set the ID from the route parameter
            await _gamingBuildsService.UpdateGamingBuildsAsync(dto);
            return Ok("Armchair updated successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArmchair(int id)
    {
        try
        {
            await _gamingBuildsService.DeleteGamingBuildsAsync(id);
            return Ok("Armchair deleted successfully.");
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
