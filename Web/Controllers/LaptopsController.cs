using Application.Common.Exceptions;
using Application.Interfaces;
using DTOS.LaptopDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LaptopsController : ControllerBase
{
    private readonly ILaptopService _laptopService;

    public LaptopsController(ILaptopService laptopService)
    {
        _laptopService = laptopService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] AddLaptopDto laptopDto)
    {
        try
        {
            _laptopService.Create(laptopDto);
            return Ok("Laptop created successfully");
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
            _laptopService.Delete(id);
            return Ok("Laptop deleted successfully");
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
            var laptops = await _laptopService.GetAllAsync();
            return Ok(laptops);
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
            var laptop = await _laptopService.GetByIdAsync(id);
            return Ok(laptop);
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
    public IActionResult Update([FromBody] UpdateLaptopDto laptopDto)
    {
        try
        {
            _laptopService.Update(laptopDto);
            return Ok("Laptop updated successfully");
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
