using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController(IS3Interface s3Interface)
    : ControllerBase
{
    private readonly IS3Interface s3Interface = s3Interface;

    [HttpPost]
    public async Task<IActionResult> UploadImageAsync(IFormFile file)
    {
        try
        {
            var fileKey = await s3Interface.UploadFileAsync(file);
            string url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/api/Images/{fileKey}";
            return Ok(url);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{fileName}")]
    public async Task<IActionResult> GetImageAsync(string fileName)
    {
        try
        {
            var file = await s3Interface.GetFileUrlAsync(fileName);
            return File(file, "image/jpeg");
        }
        catch(ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{fileName}")]
    public async Task<IActionResult> DeleteImageAsync(string fileName)
    {
        try
        {
            await s3Interface.DeleteFileAsync(fileName);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}