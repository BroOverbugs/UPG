using DTOS.CatalogCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<List<CatalogCategoryDTO>> GetCategoriesAsync();
    Task<CatalogCategoryDTO> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(AddCatalogCategoryDTO newCategory);
    Task UpdateCategoryAsync(UpdateCatalogCategoryDTO categoryDto);
    Task DeleteCategoryAsync(int id);
}
