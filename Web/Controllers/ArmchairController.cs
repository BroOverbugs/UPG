using Application.Interfaces;
using DTOS.ArmchairsDTOs;
using Microsoft.AspNetCore.Mvc;
using UPG.Core.Filters;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArmchairsController : ControllerBase
{
    private readonly IArmchairsService _armchairsService;

    public ArmchairsController(IArmchairsService armchairsService)
    {
        _armchairsService = armchairsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetArmchairs()
    {
        var armchairs = await _armchairsService.GetArmchairsAsync();
        return Ok(armchairs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArmchairById(int id)
    {
        try
        {
            var armchair = await _armchairsService.GetArmchairsByIdAsync(id);
            return Ok(armchair);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddArmchair(AddArmchairsDTO dto)
    {
        await _armchairsService.AddArmchairsAsync(dto);
        return Ok("Armchair added successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateArmchair(UpdateArmchairsDTO dto)
    {
        try
        {
            await _armchairsService.UpdateArmchairsAsync(dto);
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
            await _armchairsService.DeleteArmchairsAsync(id);
            return Ok("Armchair deleted successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] ArmchairsFilter filter)
    {
        try
        {
            var dto = await _armchairsService.Filter(filter);
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
