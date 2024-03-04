using Domain.Entities;
using Infastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface RAMInterface : IRepository<RAM>
{
    Task<List<RAM>> GetFilteredRAM(RAMFilter filter);
}
