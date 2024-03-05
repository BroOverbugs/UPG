using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infastructure.Repositories;

public class CoolerRepository(AppDBContext dBContext)
                 : Repository<Cooler>(dBContext), ICooler
{
    private readonly AppDBContext _dBContext = dBContext;
    public async Task<List<Cooler>> GetFilteredCoolersAsync(CoolerFilter filter)
    {
        var query = _dBContext.Coolers.AsQueryable();

        if (!string.IsNullOrEmpty(filter.type))
            query = query.Where(c => c.Type == filter.type);

        if (!string.IsNullOrEmpty(filter.power_dissipation))
            query = query.Where(c => c.Power_dissipation == filter.power_dissipation);

        if (!string.IsNullOrEmpty(filter.rotational_speed))
            query = query.Where(c => c.Rotational_speed == filter.rotational_speed);
        
        if (!string.IsNullOrEmpty(filter.bearing_type))
            query = query.Where(c => c.Bearing_type == filter.bearing_type);

        if (!string.IsNullOrEmpty(filter.dimensions_of_complete_fans))
            query = query.Where(c => c.Dimensions_of_complete_fans == filter.dimensions_of_complete_fans);

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
