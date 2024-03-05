using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;

namespace Infastructure.Repositories
{
    public class MonitorRepository(AppDBContext dBContext) : Repository<Domain.Entities.Monitor>(dBContext), IMonitorInterface
    {
        private readonly AppDBContext _dBContext = dBContext;

        public async Task<List<Domain.Entities.Monitor>> GetFilteredMonitor(MonitorFilter filter)
        {
            var query = _dBContext.Monitors.AsQueryable();

            if (!string.IsNullOrEmpty(filter.brand))
                query = query.Where(k => k.BrandName == filter.brand);

            if (!string.IsNullOrEmpty(filter.screenType))
                query = query.Where(k => k.Screen_type == filter.screenType);

            if (!string.IsNullOrEmpty(filter.matrixType))
                query = query.Where(k => k.Matrix_type == filter.matrixType);

            if (filter.HDR == true)
                query = query.Where(k => k.HDR);

            if (!string.IsNullOrEmpty(filter.adjustment))
                query = query.Where(k => k.Adjustment == filter.adjustment);

            if (!string.IsNullOrEmpty(filter.VESAMount))
                query = query.Where(k => k.VESA_Mount == filter.VESAMount);

            if (!string.IsNullOrEmpty(filter.frameRate))
                query = query.Where(k => k.Frame_rate == filter.frameRate);

            if (!string.IsNullOrEmpty(filter.aspectRatio))
                query = query.Where(k => k.Aspect_ratio == filter.aspectRatio);

            if (!string.IsNullOrEmpty(filter.diagonal))
                query = query.Where(k => k.Diagonal == filter.diagonal);

            if (filter.Guarantee_period == true)
                query = query.Where(k => k.Guarantee_period);

            if (filter.minPrice.HasValue)
                query = query.Where(k => k.Price >= filter.minPrice);

            if (filter.maxPrice.HasValue)
                query = query.Where(k => k.Price <= filter.maxPrice);


            query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                            .Take(filter.pageSize);

            return await query.ToListAsync();
        }
    }
}