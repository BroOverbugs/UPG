using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPG.Core.Filters;

namespace Infastructure.Repositories;

public class AccessoriesRepository(AppDBContext dbContext) : Repository<Accessories>(dbContext), IAccessoriesInterface
{
    private readonly AppDBContext _dbContext = dbContext;

    public async Task<List<Accessories>> GetFilteredAccessoriesAsync(AccessoriesFilter filter)
    {
        var query = _dbContext.Accessories.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(h => h.BrandName == filter.brand);

        if (filter.minPrice.HasValue)
            query = query.Where(h => h.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(h => h.Price <= filter.maxPrice);


        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                    .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}
