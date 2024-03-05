using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;

namespace Infastructure.Repositories;

public class ArmchairsRepository(AppDBContext dBContext)
                    : Repository<Armchairs>(dBContext), IArmchairs
{
    private readonly AppDBContext _dBContext = dBContext;
    public async Task<List<Armchairs>> GetFilteredArmchairsAsync(ArmchairsFilter filter)
    {
        var query = _dBContext.Armchairs.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(c => c.BrandName == filter.brand);

        if (filter.minPrice.HasValue)
            query = query.Where(c => c.Price >= filter.minPrice.Value);

        if (filter.maxPrice.HasValue)
            query = query.Where(h => h.Price <= filter.maxPrice);
        
        if (!string.IsNullOrEmpty(filter.type))
            query = query.Where(c => c.Type == filter.type);

        if (!string.IsNullOrEmpty(filter.upholstery_material))
            query = query.Where(c => c.Upholstery_material == filter.upholstery_material);

        if (!string.IsNullOrEmpty(filter.color_material))
            query = query.Where(c => c.Color_material == filter.color_material);

        if (!string.IsNullOrEmpty(filter.armsets))
            query = query.Where(c => c.Armrests == filter.armsets);

        if (!string.IsNullOrEmpty(filter.cross_material))
            query = query.Where(c => c.Cross_material == filter.cross_material);

        if (!string.IsNullOrEmpty(filter.reclining))
            query = query.Where(c => c.Reclining == filter.reclining);

        if (!string.IsNullOrEmpty(filter.rocking_mechanism))
            query = query.Where(c => c.Rocking_mechanism == filter.rocking_mechanism);

        if (!string.IsNullOrEmpty(filter.permissible_load))
            query = query.Where(c => c.Permissible_load == filter.permissible_load);

        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                    .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}
