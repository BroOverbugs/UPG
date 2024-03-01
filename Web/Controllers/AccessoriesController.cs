using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using DTOS.AccessoriesDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UPG.Core.Filters;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccessoriesController : ControllerBase
{
    private readonly IAccessoriesService _accessoriesService;

    public AccessoriesController(IAccessoriesService accessoriesService)
    {
        _accessoriesService = accessoriesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _accessoriesService.GetAccessoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _accessoriesService.GetAccessoriesByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddAccessoriesDto dto)
    {
        try
        {
            await _accessoriesService.AddAccessoriesAsync(dto);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ResponseErrors ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateAccessoriesDto dto)
    {
        try
        {
            await _accessoriesService.UpdateAccessoriesAsync(dto);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ResponseErrors ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]    
    public async Task<IActionResult> Delete(int id)
    {
        await _accessoriesService.DeleteAccessoriesAsync(id);
        return Ok();
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaget(int pageSize = 10, int pageNumber = 1)
    {
        var paged = await _accessoriesService.GetPagetAccessories(pageSize, pageNumber);

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

    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] AccessoriesFilter filter)
    {
        try
        {
            var accessories = await _accessoriesService.FilterAsync(filter);
            return Ok(accessories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
