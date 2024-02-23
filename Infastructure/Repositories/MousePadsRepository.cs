using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories;

public class MousePadsRepository(AppDBContext dbContext) : Repository<MousePads>(dbContext), MousePadsInterface
{
}
