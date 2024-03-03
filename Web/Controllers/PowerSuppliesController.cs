using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using DTOS.Power_supplies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UPG.Core.Filters;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PowerSuppliesController : ControllerBase
{
    private readonly IPowerSuppliesService _power_SuppliesService;
    public PowerSuppliesController(IPowerSuppliesService power_SuppliesService)
    {
        _power_SuppliesService = power_SuppliesService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categories = await _power_SuppliesService.GetPowerSuppliesAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var category = await _power_SuppliesService.GetPowerSuppliesByIdAsync(id);
            return Ok(category);
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

    [HttpPost]
    public async Task<IActionResult> Post(AddPowerSuppliesDTO dto)
    {
        try
        {
            await _power_SuppliesService.AddPowerSuppliesAsync(dto);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdatePowerSuppliesDTO dto)
    {
        try
        {
            await _power_SuppliesService.UpdatePowerSuppliesAsync(dto);
            return Ok();
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

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
        try
        { 
        await _power_SuppliesService.DeletePowerSuppliesAsync(Id);
        return Ok(); 
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
    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] PowerSuppliesFIlter filter)
    {
        try
        {
            var monitors = await _power_SuppliesService.Filter(filter);
            return Ok(monitors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
