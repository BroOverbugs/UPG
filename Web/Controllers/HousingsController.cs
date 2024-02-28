using Application.Common.Exceptions;
using Application.Interfaces;
using DTOS.HousingDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HousingsController : ControllerBase
{
    private readonly IHousingService _housingService;

    public HousingsController(IHousingService housingService)
    {
        _housingService = housingService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] AddHousingDto housingDto)
    {
        try
        {
            _housingService.Create(housingDto);
            return Ok("Housing created successfully");
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
            _housingService.Delete(id);
            return Ok("Housing deleted successfully");
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
            var housings = await _housingService.GetAllAsync();
            return Ok(housings);
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
            var housing = await _housingService.GetByIdAsync(id);
            return Ok(housing);
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
    public IActionResult Update([FromBody] UpdateHousingDto housingDto)
    {
        try
        {
            _housingService.Update(housingDto);
            return Ok("Housing updated successfully");
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
