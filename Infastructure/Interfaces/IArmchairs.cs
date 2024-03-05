using Domain.Entities;
using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface IArmchairs : IRepository<Armchairs>
{
    Task<List<Armchairs>> GetFilteredArmchairsAsync(ArmchairsFilter filter);
}
