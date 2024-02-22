using Application.Helpers;
using Application.Interfaces;
using DTOS.Power_supplies;
using DTOS.Tables_for_gamers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TablesforgamersController : ControllerBase
{
    private readonly ITables_for_gamersService _tables_for_gamersservice;
    public TablesforgamersController(ITables_for_gamersService tables_for_gamersservice)
    {
        _tables_for_gamersservice = tables_for_gamersservice;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _tables_for_gamersservice.GetTablesForGamersAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _tables_for_gamersservice.GetTablesForGamersByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddTables_for_gamersDTO dto)
    {
        try
        {
            await _tables_for_gamersservice.AddTablesForGamersAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateTables_for_gamersDTO dto)
    {
        try
        {
            await _tables_for_gamersservice.UpdateTablesForGamersAsync(dto);
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
        await _tables_for_gamersservice.DeleteTablesForGamersAsync(Id);
        return Ok();
    }
    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged(int pageSize = 10, int pageNumber = 1)
    {
        var paged = await _tables_for_gamersservice.GetPagedCategories(pageSize, pageNumber);

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
        var books = await _tables_for_gamersservice.Filter(parametrs);
        return Ok(books);
    }
}
