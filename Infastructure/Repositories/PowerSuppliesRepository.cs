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

public class PowerSuppliesRepository(AppDBContext dbContext) : Repository<PowerSupplies>(dbContext), PowerSuppliesInterface
{
    private readonly AppDBContext _dBContext = dbContext;
    public async Task<List<PowerSupplies>> GetFilteredPowerSupplies(PowerSuppliesFIlter filter)
    {
        var query = _dBContext.Power_Supplies.AsQueryable();

        if (!string.IsNullOrEmpty(filter.brand))
            query = query.Where(k => k.BrandName == filter.brand);

        if (!string.IsNullOrEmpty(filter.power))
            query = query.Where(k => k.Power == filter.power);

        if (!string.IsNullOrEmpty(filter.dimensions))
            query = query.Where(k => k.Dimensions == filter.dimensions);

        if (!string.IsNullOrEmpty(filter.securityTechnologies))
            query = query.Where(k => k.Security_technologies == filter.securityTechnologies);

        if (!string.IsNullOrEmpty(filter.formFactor))
            query = query.Where(k => k.Form_factor == filter.formFactor);

        if (!string.IsNullOrEmpty(filter.certificate))
            query = query.Where(k => k.Certificate == filter.certificate);

        if (filter.minPrice.HasValue)
            query = query.Where(k => k.Price >= filter.minPrice);

        if (filter.maxPrice.HasValue)
            query = query.Where(k => k.Price <= filter.maxPrice);


        query = query.Skip((filter.pageNumber - 1) * filter.pageSize)
                        .Take(filter.pageSize);

        return await query.ToListAsync();
    }
}
