using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories;

public class AccessoriesRepository(AppDBContext dbContext) : Repository<Accessories>(dbContext), IAccessoriesInterface
{
}
