using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories
{
    public class MonitorRepository(AppDBContext dBContext) : Repository<Domain.Entities.Monitor>(dBContext), IMonitorInterface
    {
    }
}
