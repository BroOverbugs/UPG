using Domain.Entities;
using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface IDrives : IRepository<Drives>
{
    Task<List<Drives>> GetFilteredDrivesAsync(DrivesFilter filter);
}
