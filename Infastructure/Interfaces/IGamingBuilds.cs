using Domain.Entities;
using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface IGamingBuilds : IRepository<GamingBuilds>
{
    Task<List<GamingBuilds>> GetFilteredGamingBuildsAsync(GamingBuildsFilter filter);
}
