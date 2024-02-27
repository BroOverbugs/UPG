using Application.Interfaces;
using DTOS.GamingBuildsDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamingBuildsController : ControllerBase
{
    private readonly IGamingBuildsService _gamingBuildsService;

    public GamingBuildsController(IGamingBuildsService gamingBuildsService)
    {
        _gamingBuildsService = gamingBuildsService;
    }

    // GET: api/GamingBuilds
    [HttpGet]
    public async Task<IActionResult> GetGamingBuilds()
    {
        var gamingBuilds = await _gamingBuildsService.GetGamingBuildsAsync();
        return Ok(gamingBuilds);
    }

    // GET: api/GamingBuilds/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGamingBuildsById(int id)
    {
        var gamingBuilds = await _gamingBuildsService.GetGamingBuildsByIdAsync(id);
        return Ok(gamingBuilds);
    }

    // POST: api/GamingBuilds
    [HttpPost]
    public async Task<IActionResult> CreateGamingBuilds([FromBody] AddGamingBuildsDTO gamingBuildsDTO)
    {
        await _gamingBuildsService.AddGamingBuildsAsync(gamingBuildsDTO);
        return Ok();
    }

    // PUT: api/GamingBuilds/5
    [HttpPut]
    public async Task<IActionResult> UpdateGamingBuilds(UpdateGamingBuildsDTO gamingBuildsDTO)
    {
        await _gamingBuildsService.UpdateGamingBuildsAsync(gamingBuildsDTO);
        return Ok();
    }

    // DELETE: api/GamingBuilds/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGamingBuilds(int id)
    {
        await _gamingBuildsService.DeleteGamingBuildsAsync(id);
        return Ok();
    }
}
