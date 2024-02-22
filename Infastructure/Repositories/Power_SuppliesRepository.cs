using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories;

public class Power_SuppliesRepository(AppDBContext dbContext) : Repository<Power_supplies>(dbContext), Power_suppliesInterface
{
}
