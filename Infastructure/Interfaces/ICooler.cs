using Domain.Entities;
using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface ICooler : IRepository<Cooler>
{
    Task<List<Cooler>> GetFilteredCoolersAsync(CoolerFilter filter);
}
