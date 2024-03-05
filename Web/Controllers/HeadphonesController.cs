using Application.Interfaces;
using Application.Services;
using DTOS.HeadphonesDTOs;
using Microsoft.AspNetCore.Mvc;
using UPG.Core.Filters;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeadphonesController : ControllerBase
{
    private readonly IHeadphonesService _headphonesService;

    public HeadphonesController(IHeadphonesService headphonesService)
    {
        _headphonesService = headphonesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHeadphones()
    {
        var headphones = await _headphonesService.GetHeadphonesAsync();
        return Ok(headphones);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetHeadphonesById(int id)
    {
        try
        {
            var headphones = await _headphonesService.GetHeadphonesByIdAsync(id);
            return Ok(headphones);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddHeadphones(AddHeadphonesDTO dto)
    {
        await _headphonesService.AddHeadphonesAsync(dto);
        return Ok("Headphones added successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateHeadphones(UpdateHeadphonesDTO dto)
    {
        try
        {
            await _headphonesService.UpdateHeadphonesAsync(dto);
            return Ok("Headphones updated successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHeadphones(int id)
    {
        try
        {
            await _headphonesService.DeleteHeadphonesAsync(id);
            return Ok("Headphones deleted successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] HeadphonesFilter filter)
    {
        try
        {
            var dto = await _headphonesService.Filter(filter);
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
