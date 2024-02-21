using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories
{
    public class LaptopRepository(AppDBContext dBContext) : Repository<Laptop>(dBContext), ILaptopInterface
    {
    }
}
