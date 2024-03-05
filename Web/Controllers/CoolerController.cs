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
    public async Task<IActionResult> GetCoolerById(int id)
    {
        try
        {
            var cooler = await _coolerService.GetCoolerByIdAsync(id);
            return Ok(cooler);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddCooler(AddCoolerDTO dto)
    {
        await _coolerService.AddCoolerAsync(dto);
        return Ok("Cooler added successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCooler(UpdateCoolerDTO dto)
    {
        try
        {
            await _coolerService.UpdateCoolerAsync(dto);
            return Ok("Cooler updated successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCooler(int id)
    {
        try
        {
            await _coolerService.DeleteCoolerAsync(id);
            return Ok("Cooler deleted successfully.");
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
