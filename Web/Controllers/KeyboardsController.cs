using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Services;
using DTOS.KeyboardDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPG.Core.Filters;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KeyboardsController : ControllerBase
{
    private readonly IKeyboardService _keyboardService;

    public KeyboardsController(IKeyboardService keyboardService)
    {
        _keyboardService = keyboardService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AddKeyboardDto keyboardDto)
    {
        try
        {
            await _keyboardService.Create(keyboardDto);
            return Ok("Keyboard created successfully");
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
            await _keyboardService.Delete(id);
            return Ok("Keyboard deleted successfully");
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
            var keyboards = await _keyboardService.GetAllAsync();
            return Ok(keyboards);
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
            var keyboard = await _keyboardService.GetByIdAsync(id);
            return Ok(keyboard);
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
    public async Task<IActionResult> Update([FromBody] UpdateKeyboardDto keyboardDto)
    {
        try
        {
            await _keyboardService.Update(keyboardDto);
            return Ok("Keyboard updated successfully");
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
    public async Task<IActionResult> GetByFilterAsync([FromQuery] KeyboardFilter filter)
    {
        try
        {
            var keyboards = await _keyboardService.FilterAsync(filter);
            return Ok(keyboards);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}