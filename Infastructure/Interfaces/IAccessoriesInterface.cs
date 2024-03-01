using Domain.Entities;
using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface IAccessoriesInterface : IRepository<Accessories>
{
    Task<List<Accessories>> GetFilteredAccessoriesAsync(AccessoriesFilter filter);
}
