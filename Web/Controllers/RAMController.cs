using Application.Helpers;
using Application.Interfaces;
using DTOS.Power_supplies;
using DTOS.RAM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        var categories = await _ramservice.GetRAMAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _ramservice.GetRAMByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddRAMDTO dto)
    {
        try
        {
            await _ramservice.AddRAMAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
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
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
        await _ramservice.DeleteRAMAsync(Id);
        return Ok();
    }
    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged(int pageSize = 10, int pageNumber = 1)
    {
        var paged = await _ramservice.GetPagedRAMs(pageSize, pageNumber);

        var metaData = new
        {
            paged.TotalCount,
            paged.PageSize,
            paged.CurrentPage,
            paged.HasNext,
            paged.HasPrevious
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

        return Ok(paged.Data);
    }
    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] FilterParameters parametrs)
    {
        var books = await _ramservice.Filter(parametrs);
        return Ok(books);
    }
}
