using Application.Interfaces;
using AutoMapper;
using Domain.Categories;
using DTOS.CatalogCat;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task AddCategoryAsync(AddCatalogCategoryDTO newCategory)
    {
        var book = _mapper.Map<Catalogcategory>(newCategory);
        await _unitOfWork.CatalogCategory.AddAsync(book);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        _unitOfWork.CatalogCategory.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<CatalogCategoryDTO>> GetCategoriesAsync()
    {
        var categories = await _unitOfWork.CatalogCategory.GetAllAsync();
        var categoryDtos = _mapper.Map<List<CatalogCategoryDTO>>(categories);
        return categoryDtos;
    }

    public async Task<CatalogCategoryDTO> GetCategoryByIdAsync(int id)
    {
        var book = await _unitOfWork.CatalogCategory.GetByIdAsync(id);
        return _mapper.Map<CatalogCategoryDTO>(book);
    }

    public async Task UpdateCategoryAsync(UpdateCatalogCategoryDTO categoryDto)
    {
        var category = _mapper.Map<Catalogcategory>(categoryDto);
        _unitOfWork.CatalogCategory.Update(category);
        await _unitOfWork.SaveAsync();
    }
}
