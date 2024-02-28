using Application.Common.Exceptions;
using Application.Interfaces;
using DTOS.MiceDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MicesController : ControllerBase
{
    private readonly IMiceService _miceService;

    public MicesController(IMiceService miceService)
    {
        _miceService = miceService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] AddMiceDto miceDto)
    {
        try
        {
            _miceService.Create(miceDto);
            return Ok("Mice created successfully");
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
    public IActionResult Delete(int id)
    {
        try
        {
            _miceService.Delete(id);
            return Ok("Mice deleted successfully");
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
            var mices = await _miceService.GetAllAsync();
            return Ok(mices);
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
            var mice = await _miceService.GetByIdAsync(id);
            return Ok(mice);
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
    public IActionResult Update([FromBody] UpdateMiceDto miceDto)
    {
        try
        {
            _miceService.Update(miceDto);
            return Ok("Mice updated successfully");
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
}
