using Application.Interfaces;
using DTOS.ArmchairsDTOs;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArmchair(int id, UpdateArmchairsDTO dto)
    {
        try
        {
            dto.ID = id; // Set the ID from the route parameter
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
}
