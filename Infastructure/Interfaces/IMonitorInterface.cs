using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface IMonitorInterface : IRepository<Domain.Entities.Monitor>
{
    Task<List<Domain.Entities.Monitor>> GetFilteredMonitor(MonitorFilter filter);
}
