using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories;

public class CoolerRepository(AppDBContext dBContext) 
                 : Repository<Cooler>(dBContext), ICooler
{
}
