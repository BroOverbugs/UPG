using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces;
using DTOS.Mouse_pads;
using DTOS.Power_supplies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MousePadsController : ControllerBase
{
    private readonly IMousePadsService _power_SuppliesService;
    public MousePadsController(IMousePadsService power_SuppliesService)
    {
        _power_SuppliesService = power_SuppliesService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categories = await _power_SuppliesService.GetMousePadsAsync();
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
            var category = await _power_SuppliesService.GetMousePadByIdAsync(id);
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
    public async Task<IActionResult> Post(AddMousePadsDTO dto)
    {
        try
        {
            await _power_SuppliesService.AddMousePadsAsync(dto);
            return Ok();
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

    [HttpPut]
    public async Task<IActionResult> Put(UpdateMousePadsDTO dto)
    {
        try
        {
            await _power_SuppliesService.UpdateMousePadsAsync(dto);
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
            await _power_SuppliesService.DeleteMousePadsAsync(Id);
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
    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged(int pageSize = 10, int pageNumber = 1)
    {
        var paged = await _power_SuppliesService.GetPagetMousePads(pageSize, pageNumber);

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
