using Application.Helpers;
using Application.Interfaces;
using DTOS.RAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class RAMService : IRAMService
{
    public Task AddCategoryAsync(AddRAMDTO ram)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<RAMDTO>> Filter(FilterParameters parametrs)
    {
        throw new NotImplementedException();
    }

    public Task<List<RAMDTO>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RAMDTO> GetCategoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<RAMDTO>> GetPagetCategories(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(UpdateRAMDTO ram)
    {
        throw new NotImplementedException();
    }
}
