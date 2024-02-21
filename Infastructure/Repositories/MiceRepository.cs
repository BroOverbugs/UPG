using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories
{
    public class MiceRepository(AppDBContext dBContext) : Repository<Mice>(dBContext), IMiceInterface
    {
    }
}
