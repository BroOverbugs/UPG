using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;

namespace Infastructure.Repositories;

public class MiceRepository(AppDBContext dBContext) : Repository<Mice>(dBContext), IMiceInterface
{
    private readonly AppDBContext _dBContext = dBContext;

    public async Task<List<Mice>> GetFilteredMice(MiceFilter filter)
    {
        var query = _dBContext.Mices.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(k => k.BrandName == filter.brand);

        if (!string.IsNullOrEmpty(filter.pollingRate))
            query = query.Where(k => k.Polling_rate == filter.pollingRate);

        if (filter.numberOfButtons.HasValue)
            query = query.Where(k => k.Number_of_buttons == filter.numberOfButtons);

        if (!string.IsNullOrEmpty(filter.maximumResolutionDPIOrCPI))
            query = query.Where(k => k.Maximum_resolution_DPI_or_CPI == filter.maximumResolutionDPIOrCPI);

        if (!string.IsNullOrEmpty(filter.acceleration))
            query = query.Where(k => k.Acceleration_max_acceleration == filter.acceleration);

        if (!string.IsNullOrEmpty(filter.sensorType))
            query = query.Where(k => k.Sensor_type == filter.sensorType);

        if (!string.IsNullOrEmpty(filter.operatingMode))
            query = query.Where(k => k.Operating_mode == filter.operatingMode);

        if (filter.minPrice.HasValue)
            query = query.Where(k => k.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(k => k.Price <= filter.maxPrice);


        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                        .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}
