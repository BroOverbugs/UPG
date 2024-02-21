using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories
{
    public class HousingRepository(AppDBContext dbContext) : Repository<Housing>(dbContext), IHousingInterface
    {
    }
}
