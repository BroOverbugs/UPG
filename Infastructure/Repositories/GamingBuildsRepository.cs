using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;

namespace Infastructure.Repositories;

public class GamingBuildsRepository(AppDBContext dBContext)
                        : Repository<GamingBuilds>(dBContext), IGamingBuilds
{
    private readonly AppDBContext _dBContext = dBContext;
    public async Task<List<GamingBuilds>> GetFilteredGamingBuildsAsync(GamingBuildsFilter filter)
    {
        var query = _dBContext.GamingBuilds.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(h => h.BrandName == filter.brand);

        if (filter.minPrice.HasValue)
            query = query.Where(h => h.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(h => h.Price <= filter.maxPrice);

        if (!string.IsNullOrEmpty(filter.Case))
            query = query.Where(h => h.Case == filter.Case);

        if (!string.IsNullOrEmpty(filter.CPU))
            query = query.Where(h => h.CPU == filter.CPU);

        if (!string.IsNullOrEmpty(filter.GPU))
            query = query.Where(h => h.GPU == filter.GPU);

        if (!string.IsNullOrEmpty(filter.RAM))
            query = query.Where(h => h.RAM == filter.RAM);

        if (!string.IsNullOrEmpty(filter.HDD))
            query = query.Where(h => h.HDD == filter.HDD);

        if (!string.IsNullOrEmpty(filter.SSD))
            query = query.Where(h => h.SSD == filter.SSD);

        if (!string.IsNullOrEmpty (filter.PSU))
            query = query.Where(h => h.PSU == filter.PSU);

        if (!string.IsNullOrEmpty(filter.motherBoard))
            query = query.Where(h => h.MotherBoard == filter.motherBoard);

        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                    .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}
