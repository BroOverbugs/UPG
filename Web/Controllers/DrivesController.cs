using Application.Interfaces;
using DTOS.DrivesDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrivesController : ControllerBase
{
    private readonly IDrivesService _coolerService;

    public DrivesController(IDrivesService coolerService)
    {
        _coolerService = coolerService;
    }

    // GET: api/Drives
    [HttpGet]
    public async Task<IActionResult> GetDrives()
    {
        var coolers = await _coolerService.GetDrivesAllAsync();
        return Ok(coolers);
    }

    // GET: api/Drives/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDrivesById(int id)
    {
        var cooler = await _coolerService.GetDrivesByIdAsync(id);
        if (cooler == null)
        {
            return NotFound();
        }
        return Ok(cooler);
    }

    // POST: api/Drives
    [HttpPost]
    public async Task<IActionResult> AddDrives(AddDrivesDTO coolerDTO)
    {
        await _coolerService.AddDrivesAsync(coolerDTO);
        return Ok();
    }

    // PUT: api/Drives/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDrives(int id, UpdateDrivesDTO coolerDTO)
    {
        if (id != coolerDTO.ID)
        {
            return BadRequest();
        }

        await _coolerService.UpdateDrivesAsync(coolerDTO);
        return NoContent();
    }

    // DELETE: api/Drives/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDrives(int id)
    {
        await _coolerService.DeleteDrivesAsync(id);
        return NoContent();
    }
}
