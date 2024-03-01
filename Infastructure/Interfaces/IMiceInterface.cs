using Domain.Entities;
using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface IMiceInterface : IRepository<Mice>
{
    Task<List<Mice>> GetFilteredMice(MiceFilter filter);
}
