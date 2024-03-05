using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;

namespace Infastructure.Repositories;

public class HeadphonesRepository(AppDBContext dBContext)
                     : Repository<Headphones>(dBContext), IHeadphones
{
    private readonly AppDBContext _dBContext = dBContext;
    public async Task<List<Headphones>> GetFilteredHeadphonesAsync(HeadphonesFilter filter)
    {
        var query = _dBContext.Headphones.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(h => h.BrandName == filter.brand);

        if (filter.minPrice.HasValue)
            query = query.Where(h => h.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(h => h.Price <= filter.maxPrice);

        if (!string.IsNullOrEmpty(filter.sount_type))
            query = query.Where(h => h.Sound_type == filter.sount_type);

        if (!string.IsNullOrEmpty(filter.operating_mode))
            query = query.Where(h => h.Operating_mode == filter.operating_mode);

        if (!string.IsNullOrEmpty(filter.headphone_type))
            query = query.Where(h => h.Headphone_type == filter.headphone_type);

        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                    .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}
