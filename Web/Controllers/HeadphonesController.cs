using Application.Interfaces;
using DTOS.HeadphonesDTOs;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> GetArmchairById(int id)
    {
        try
        {
            var armchair = await _headphonesService.GetHeadphonesByIdAsync(id);
            return Ok(armchair);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddArmchair(AddHeadphonesDTO dto)
    {
        await _headphonesService.AddHeadphonesAsync(dto);
        return Ok("Armchair added successfully.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArmchair(int id, UpdateHeadphonesDTO dto)
    {
        try
        {
            dto.ID = id; // Set the ID from the route parameter
            await _headphonesService.UpdateHeadphonesAsync(dto);
            return Ok("Armchair updated successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArmchair(int id)
    {
        try
        {
            await _headphonesService.DeleteHeadphonesAsync(id);
            return Ok("Armchair deleted successfully.");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
