using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Filters;

namespace Infastructure.Repositories;

public class KeyboardRepository(AppDBContext dBContext) : Repository<Keyboard>(dBContext), IKeyboardInterface
{
    private readonly AppDBContext _dBContext = dBContext;

    public async Task<List<Keyboard>> GetFilteredKeyboard(KeyboardFilter filter)
    {
        var query = _dBContext.Keyboards.AsQueryable();

        // Apply filters
        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(k => k.BrandName == filter.brand);

        if (!string.IsNullOrEmpty(filter.switchType))
            query = query.Where(k => k.Switch_type == filter.switchType);

        if (!string.IsNullOrEmpty(filter.keyboardType))
            query = query.Where(k => k.Keyboard_type == filter.keyboardType);

        if (!string.IsNullOrEmpty(filter.backlight))
            query = query.Where(k => k.Backlight == filter.backlight);

        if (filter.minPrice.HasValue)
            query = query.Where(k => k.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(k => k.Price <= filter.maxPrice);


        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                        .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}