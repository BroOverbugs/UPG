using Application.Helpers;
using Application.Interfaces;
using DTOS.Power_supplies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PowerSuppliesController : ControllerBase
{
    private readonly IPower_suppliesService _power_SuppliesService;
    public PowerSuppliesController(IPower_suppliesService power_SuppliesService)
    {
        _power_SuppliesService = power_SuppliesService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _power_SuppliesService.GetPowerSuppliesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _power_SuppliesService.GetPowerSuppliesByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddPower_suppliesDTO dto)
    {
        try
        {
            await _power_SuppliesService.AddPowerSuppliesAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdatePower_suppliesDTO dto)
    {
        try
        {
            await _power_SuppliesService.UpdatePowerSuppliesAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
        await _power_SuppliesService.DeletePowerSuppliesAsync(Id);
        return Ok();
    }
    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged(int pageSize = 10, int pageNumber = 1)
    {
        var paged = await _power_SuppliesService.GetPagedPowerSupplies(pageSize, pageNumber);

        var metaData = new
        {
            paged.TotalCount,
            paged.PageSize,
            paged.CurrentPage,
            paged.HasNext,
            paged.HasPrevious
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

        return Ok(paged.Data);
    }
    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] FilterParameters parametrs)
    {
        var books = await _power_SuppliesService.Filter(parametrs);
        return Ok(books);
    }
}
