﻿using Domain.Entities;
using Infastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface TablesForGamersInterface : IRepository<TablesForGamers>
{
    Task<List<TablesForGamers>> GetFilteredTablesForGamers(TablesForGamersFilter filter);
}
