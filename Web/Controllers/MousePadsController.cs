using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using DTOS.Mouse_pads;
using DTOS.Power_supplies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UPG.Core.Filters;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MousePadsController : ControllerBase
{
    private readonly IMousePadsService _mousePadsService;
    public MousePadsController(IMousePadsService mousePadsService)
    {
        _mousePadsService = mousePadsService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categories = await _mousePadsService.GetMousePadsAsync();
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
            var category = await _mousePadsService.GetMousePadByIdAsync(id);
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
            await _mousePadsService.AddMousePadsAsync(dto);
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
            await _mousePadsService.UpdateMousePadsAsync(dto);
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
            await _mousePadsService.DeleteMousePadsAsync(Id);
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
    public async Task<IActionResult> GetByFilterAsync([FromQuery] MousePadsFilter filter)
    {
        try
        {
            var monitors = await _mousePadsService.Filter(filter);
            return Ok(monitors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
