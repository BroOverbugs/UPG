using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;

namespace Infastructure.Repositories
{
    public class LaptopRepository(AppDBContext dBContext) : Repository<Laptop>(dBContext), ILaptopInterface
    {
        private readonly AppDBContext _dBContext = dBContext;

        public async Task<List<Laptop>> GetFilteredLaptop(LaptopFilter filter)
        {
            var query = _dBContext.Laptops.AsQueryable();

            if (!string.IsNullOrEmpty(filter.brand))
                query = query.Where(k => k.BrandName == filter.brand);

            if (!string.IsNullOrEmpty(filter.processor))
                query = query.Where(k => k.Processor == filter.processor);

            if (!string.IsNullOrEmpty(filter.storage))
                query = query.Where(k => k.Storage == filter.storage);

            if (!string.IsNullOrEmpty(filter.RAM))
                query = query.Where(k => k.RAM == filter.RAM);

            if (!string.IsNullOrEmpty(filter.videoCard))
                query = query.Where(k => k.Video_card == filter.videoCard);

            if (!string.IsNullOrEmpty(filter.screen))
                query = query.Where(k => k.Screen == filter.screen);

            if (!string.IsNullOrEmpty(filter.WiFi))
                query = query.Where(k => k.Wi_Fi == filter.WiFi);

            if (!string.IsNullOrEmpty(filter.RTXAMD))
                query = query.Where(k => k.RTX_or_AMD == filter.RTXAMD);

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
