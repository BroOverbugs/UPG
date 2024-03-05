using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using DTOS.Power_supplies;
using DTOS.Tables_for_gamers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UPG.Core.Filters;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TablesforgamersController : ControllerBase
{
    private readonly ITablesForGamersService _tables_for_gamersservice;
    public TablesforgamersController(ITablesForGamersService tables_for_gamersservice)
    {
        _tables_for_gamersservice = tables_for_gamersservice;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categories = await _tables_for_gamersservice.GetTablesForGamersAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var category = await _tables_for_gamersservice.GetTablesForGamersByIdAsync(id);
            return Ok(category);
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

    [HttpPost]
    public async Task<IActionResult> Post(AddTablesForGamersDTO dto)
    {
        try
        {
            await _tables_for_gamersservice.AddTablesForGamersAsync(dto);
            return Ok();
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

    [HttpPut]
    public async Task<IActionResult> Put(UpdateTablesForGamersDTO dto)
    {
        try
        {
            await _tables_for_gamersservice.UpdateTablesForGamersAsync(dto);
            return Ok();
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

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
        try
        {
            await _tables_for_gamersservice.DeleteTablesForGamersAsync(Id);
            return Ok();
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
    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] TablesForGamersFilter filter)
    {
        try
        {
            var monitors = await _tables_for_gamersservice.Filter(filter);
            return Ok(monitors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
