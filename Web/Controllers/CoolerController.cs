using Application.Interfaces;
using Application.Services;
using DTOS.CoolerDTOs;
using Microsoft.AspNetCore.Mvc;
using UPG.Core.Filters;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoolerController : ControllerBase
{
    private readonly ICoolerService _coolerService;

    public CoolerController(ICoolerService coolerService)
    {
        _coolerService = coolerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCooler()
    {
        var cooler = await _coolerService.GetCoolersAsync();
        return Ok(cooler);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArmchairById(int id)
    {
        try
        {
            var armchair = await _coolerService.GetCoolerByIdAsync(id);
            return Ok(armchair);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddArmchair(AddCoolerDTO dto)
    {
        await _coolerService.AddCoolerAsync(dto);
        return Ok("Armchair added successfully.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArmchair(int id, UpdateCoolerDTO dto)
    {
        try
        {
            dto.ID = id; // Set the ID from the route parameter
            await _coolerService.UpdateCoolerAsync(dto);
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
            await _coolerService.DeleteCoolerAsync(id);
            return Ok("Armchair deleted successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] CoolerFilter filter)
    {
        try
        {
            var dto = await _coolerService.Filter(filter);
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
