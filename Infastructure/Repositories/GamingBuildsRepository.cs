using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories;

public class GamingBuildsRepository(AppDBContext dBContext) 
                        : Repository<GamingBuilds>(dBContext), IGamingBuilds
{
}
