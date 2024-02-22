﻿using Application.Helpers;
using DTOS.Mouse_pads;
using DTOS.RAM;

namespace Application.Interfaces;

public interface IRAMService
{
    Task<PagedList<RAMDTO>> Filter(FilterParameters parametrs);
    Task<PagedList<RAMDTO>> GetPagetCategories(int pageSize, int pageNumber);
    Task<List<RAMDTO>> GetCategoriesAsync();
    Task<RAMDTO> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(AddRAMDTO ram);
    Task UpdateCategoryAsync(UpdateRAMDTO ram);
    Task DeleteCategoryAsync(int id);
}