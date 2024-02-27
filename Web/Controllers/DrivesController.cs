using Application.Interfaces;
using DTOS.DrivesDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrivesController : ControllerBase
{
    private readonly IDrivesService _drivesService;

    public DrivesController(IDrivesService drivesService)
    {
        _drivesService = drivesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDrives()
    {
        var drives = await _drivesService.GetDrivesAllAsync();
        return Ok(drives);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArmchairById(int id)
    {
        try
        {
            var armchair = await _drivesService.GetDrivesByIdAsync(id);
            return Ok(armchair);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddArmchair(AddDrivesDTO dto)
    {
        await _drivesService.AddDrivesAsync(dto);
        return Ok("Armchair added successfully.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArmchair(int id, UpdateDrivesDTO dto)
    {
        try
        {
            dto.ID = id; // Set the ID from the route parameter
            await _drivesService.UpdateDrivesAsync(dto);
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
            await _drivesService.DeleteDrivesAsync(id);
            return Ok("Armchair deleted successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
