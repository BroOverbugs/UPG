using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories;

public class ArmchairsRepository(AppDBContext dBContext) 
                    : Repository<Armchairs>(dBContext), IArmchairs
{
}
