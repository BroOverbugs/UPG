using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPG.Core.Filters;

namespace Infastructure.Repositories;

public class MousePadsRepository(AppDBContext dbContext) : Repository<MousePads>(dbContext), MousePadsInterface
{
    private readonly AppDBContext _dBContext = dbContext;
    public async Task<List<MousePads>> GetFilteredMousePads(MousePadsFilter filter)
    {
        var query = _dBContext.Mouse_Pads.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(k => k.BrandName == filter.brand);

        if (!string.IsNullOrEmpty(filter.dimensions))
            query = query.Where(k => k.Dimensions == filter.dimensions);

        if (!string.IsNullOrEmpty(filter.material))
            query = query.Where(k => k.Material == filter.material);

        if (filter.minPrice.HasValue)
            query = query.Where(k => k.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(k => k.Price <= filter.maxPrice);


        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                        .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}
