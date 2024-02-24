using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories;

public class DrivesRepository(AppDBContext dBContext) 
                 : Repository<Drives>(dBContext), IDrives
{
}
