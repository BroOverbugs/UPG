using Domain.Entities;
using Infastructure.Data;
using UPG.Core.Filters;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repositories
{
    public class HousingRepository(AppDBContext dbContext) : Repository<Housing>(dbContext), IHousingInterface
    {
        private readonly AppDBContext _dbContext = dbContext;

        public async Task<List<Housing>> GetFilteredHousingsAsync(HousingFilter filter)
        {
            var query = _dbContext.Housings.AsQueryable();

            if (!string.IsNullOrEmpty(filter.brand))
                query = query.Where(h => h.BrandName == filter.brand);

            if (!string.IsNullOrEmpty(filter.maximumCoolerHeight))
                query = query.Where(h => h.Maximum_cooler_height == filter.maximumCoolerHeight);

            if (!string.IsNullOrEmpty(filter.videoCard))
                query = query.Where(h => h.Maximum_video_card_length == filter.videoCard);

            if (!string.IsNullOrEmpty(filter.dimensions))
                query = query.Where(h => h.Dimensions == filter.dimensions);

            if (!string.IsNullOrEmpty(filter.PossibilityOfInstalling))
                query = query.Where(h => h.Possibility_of_installing_liquid_cooling == filter.PossibilityOfInstalling);

            if (!string.IsNullOrEmpty(filter.color))
                query = query.Where(h => h.Case_color == filter.color);

            if (filter.minPrice.HasValue)
                query = query.Where(h => h.Price >= filter.minPrice);

            if (filter.maxPrice.HasValue)
                query = query.Where(h => h.Price <= filter.maxPrice);


            query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                        .Take(filter.pageSize);

            return await query.ToListAsync();
        }
    }
}