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

public class RAMRepository(AppDBContext dbContext) : Repository<RAM>(dbContext), RAMInterface
{
    private readonly AppDBContext _dBContext = dbContext;
    public async Task<List<RAM>> GetFilteredRAM(RAMFilter filter)
    {
        var query = _dBContext.RAMs.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(k => k.BrandName == filter.brand);

        if (!string.IsNullOrEmpty(filter.capacity))
            query = query.Where(k => k.Capacity == filter.capacity);

        if (!string.IsNullOrEmpty(filter.memoryFrequency))
            query = query.Where(k => k.Memory_frequency == filter.memoryFrequency);

        if (filter.backlight == true)
            query = query.Where(k => k.Backlight);

        if (!string.IsNullOrEmpty(filter.timings))
            query = query.Where(k => k.Timings == filter.timings);

        if (!string.IsNullOrEmpty(filter.technologies))
            query = query.Where(k => k.Technologies == filter.technologies);

        if (filter.minPrice.HasValue)
            query = query.Where(k => k.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(k => k.Price <= filter.maxPrice);


        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                        .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}
