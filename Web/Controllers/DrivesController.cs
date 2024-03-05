using Application.Interfaces;
using Application.Services;
using DTOS.DrivesDTOs;
using Microsoft.AspNetCore.Mvc;
using UPG.Core.Filters;

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
    public async Task<IActionResult> GetDrivesById(int id)
    {
        try
        {
            var drives = await _drivesService.GetDrivesByIdAsync(id);
            return Ok(drives);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddDrives(AddDrivesDTO dto)
    {
        await _drivesService.AddDrivesAsync(dto);
        return Ok("Drives added successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDrives(UpdateDrivesDTO dto)
    {
        try
        {
            await _drivesService.UpdateDrivesAsync(dto);
            return Ok("Drives updated successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDrives(int id)
    {
        try
        {
            await _drivesService.DeleteDrivesAsync(id);
            return Ok("Drives deleted successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] DrivesFilter filter)
    {
        try
        {
            var dto = await _drivesService.Filter(filter);
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
