using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using DTOS.Power_supplies;
using DTOS.RAM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UPG.Core.Filters;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RAMController : ControllerBase
{
    private readonly IRAMService _ramservice;
    public RAMController(IRAMService ramservice)
    {
        _ramservice = ramservice;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categories = await _ramservice.GetRAMAsync();
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
            var category = await _ramservice.GetRAMByIdAsync(id);
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
    public async Task<IActionResult> Post(AddRAMDTO dto)
    {
        try
        {
            await _ramservice.AddRAMAsync(dto);
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
    public async Task<IActionResult> Put(UpdateRAMDTO dto)
    {
        try
        {
            await _ramservice.UpdateRAMAsync(dto);
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
            await _ramservice.DeleteRAMAsync(Id);
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
    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] RAMFilter filter)
    {
        try
        {
            var monitors = await _ramservice.Filter(filter);
            return Ok(monitors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
