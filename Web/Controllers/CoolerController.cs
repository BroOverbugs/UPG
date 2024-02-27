using Application.Interfaces;
using DTOS.CoolerDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoolerController : ControllerBase
{
    private readonly ICoolerService _coolerService;

    public CoolerController(ICoolerService coolerService)
    {
        _coolerService = coolerService;
    }

    // GET: api/Cooler
    [HttpGet]
    public async Task<IActionResult> GetCoolers()
    {
        var coolers = await _coolerService.GetCoolersAsync();
        return Ok(coolers);
    }

    // GET: api/Cooler/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoolerById(int id)
    {
        var cooler = await _coolerService.GetCoolerByIdAsync(id);
        if (cooler == null)
        {
            return NotFound();
        }
        return Ok(cooler);
    }

    // POST: api/Cooler
    [HttpPost]
    public async Task<IActionResult> AddCooler(AddCoolerDTO coolerDTO)
    {
        await _coolerService.AddCoolerAsync(coolerDTO);
        return Ok();
    }

    // PUT: api/Cooler/5
    [HttpPut]
    public async Task<IActionResult> UpdateCooler(UpdateCoolerDTO coolerDTO)
    {
        await _coolerService.UpdateCoolerAsync(coolerDTO);
        return NoContent();
    }

    // DELETE: api/Cooler/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCooler(int id)
    {
        await _coolerService.DeleteCoolerAsync(id);
        return NoContent();
    }
}
