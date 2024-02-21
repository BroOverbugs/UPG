using Application.Interfaces;
using DTOS.CatalogCat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _categoryService.GetCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddCatalogCategoryDTO dto)
    {
        try
        {
            await _categoryService.AddCategoryAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateCatalogCategoryDTO category)
    {
        try
        {
            await _categoryService.UpdateCategoryAsync(category);
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
        await _categoryService.DeleteCategoryAsync(Id);
        return Ok();
    }
}
