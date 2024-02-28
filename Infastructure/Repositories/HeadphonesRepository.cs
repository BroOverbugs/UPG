using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories;

public class HeadphonesRepository(AppDBContext dBContext) 
                     : Repository<Headphones>(dBContext), IHeadphones
{
}
