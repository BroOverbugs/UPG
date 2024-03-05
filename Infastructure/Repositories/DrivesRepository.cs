using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infastructure.Repositories;

public class DrivesRepository(AppDBContext dBContext) 
                 : Repository<Drives>(dBContext), IDrives
{
    private readonly AppDBContext _dBContext = dBContext;
    public async Task<List<Drives>> GetFilteredDrivesAsync(DrivesFilter filter)
    {
        var query = _dBContext.Drives.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(h => h.BrandName == filter.brand);

        if (filter.minPrice.HasValue)
            query = query.Where(h => h.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(h => h.Price <= filter.maxPrice);

        if (!string.IsNullOrEmpty(filter.Interface))
            query = query.Where(h => h.Interface == filter.Interface);

        if (!string.IsNullOrEmpty(filter.reading_speed))
            query = query.Where(h => h.Reading_speed == filter.reading_speed);

        if (!string.IsNullOrEmpty(filter.write_type))
            query = query.Where(h => h.Write_type == filter.write_type);

        if (!string.IsNullOrEmpty(filter.drive_type))
            query = query.Where(h => h.Drive_type == filter.drive_type);

        if (!string.IsNullOrEmpty(filter.volume))
            query = query.Where(h => h.Volume == filter.volume);

        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                    .Take(filter.pageSize);

        return await query.ToListAsync();
    }

}
