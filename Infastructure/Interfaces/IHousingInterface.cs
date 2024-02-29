using Domain.Entities;
using UPG.Core.Filters;
using Infastructure.Interface;

namespace Infastructure.Interfaces;

public interface IHousingInterface : IRepository<Housing>
{
    Task<List<Housing>> GetFilteredHousingsAsync(HousingFilter filter);
}
