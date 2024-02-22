using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories;

public class Tables_for_gamersRepository(AppDBContext dbContext) : Repository<Tables_for_gamers>(dbContext), Tables_for_gamersInterface
{
}
