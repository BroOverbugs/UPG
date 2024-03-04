using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;

namespace Infastructure.Repositories;

public class TablesForGamersRepository(AppDBContext dbContext) : Repository<TablesForGamers>(dbContext), TablesForGamersInterface
{
    private readonly AppDBContext _dBContext = dbContext;
    public async Task<List<TablesForGamers>> GetFilteredTablesForGamers(TablesForGamersFilter filter)
    {
        var query = _dBContext.Tables_For_Gamers.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(k => k.BrandName == filter.brand);

        if (!string.IsNullOrEmpty(filter.dimensions))
            query = query.Where(k => k.Dimensions == filter.dimensions);

        if (!string.IsNullOrEmpty(filter.tableAdjustment))
            query = query.Where(k => k.Table_adjustment == filter.tableAdjustment);

        if (filter.backlight == true)
            query = query.Where(k => k.Backlight);

        if (!string.IsNullOrEmpty(filter.weight))
            query = query.Where(k => k.Weight == filter.weight);

        if (!string.IsNullOrEmpty(filter.maxLoadUp))
            query = query.Where(k => k.Max_load_up == filter.maxLoadUp);

        if (filter.minPrice.HasValue)
            query = query.Where(k => k.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(k => k.Price <= filter.maxPrice);


        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                        .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}
