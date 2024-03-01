using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Services;
using DTOS.MonitorDTOs;
using Microsoft.AspNetCore.Mvc;
using UPG.Core.Filters;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MonitorsController : ControllerBase
{
    private readonly IMonitorService _monitorService;

    public MonitorsController(IMonitorService monitorService)
    {
        _monitorService = monitorService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddMonitorDto monitorDto)
    {
        try
        {
            await _monitorService.Create(monitorDto);
            return Ok("Monitor created successfully");
        }
        catch (ResponseErrors ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _monitorService.Delete(id);
            return Ok("Monitor deleted successfully");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var monitors = await _monitorService.GetAllAsync();
            return Ok(monitors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var monitor = await _monitorService.GetByIdAsync(id);
            return Ok(monitor);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMonitorDto monitorDto)
    {
        try
        {
            await _monitorService.Update(monitorDto);
            return Ok("Monitor updated successfully");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ResponseErrors ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] MonitorFilter filter)
    {
        try
        {
            var monitors = await _monitorService.FilterAsync(filter);
            return Ok(monitors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}