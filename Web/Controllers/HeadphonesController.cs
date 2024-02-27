using Application.Interfaces;
using DTOS.HeadphonesDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeadphonesController : ControllerBase
{
    private readonly IHeadphonesService _headphonesService;

    public HeadphonesController(IHeadphonesService headphonesService)
    {
        _headphonesService = headphonesService;
    }

    // GET: api/Headphones
    [HttpGet]
    public async Task<IActionResult> GetHeadphones()
    {
        var headphones = await _headphonesService.GetHeadphonesAsync();
        return Ok(headphones);
    }

    // GET: api/Headphones/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHeadphonesById(int id)
    {
        var headphones = await _headphonesService.GetHeadphonesByIdAsync(id);
        return Ok(headphones);
    }

    // POST: api/Headphones
    [HttpPost]
    public async Task<IActionResult> AddHeadphones(AddHeadphonesDTO dto)
    {
        await _headphonesService.AddHeadphonesAsync(dto);
        return Ok();
    }

    // PUT: api/Headphones/5
    [HttpPut]
    public async Task<IActionResult> UpdateHeadphones(UpdateHeadphonesDTO dto)
    {
        await _headphonesService.UpdateHeadphonesAsync(dto);
        return Ok();
    }

    // DELETE: api/Headphones/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHeadphones(int id)
    {
        await _headphonesService.DeleteHeadphonesAsync(id);
        return Ok();
    }
}
