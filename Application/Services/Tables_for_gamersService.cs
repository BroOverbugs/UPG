using Application.Helpers;
using Application.Interfaces;
using DTOS.Tables_for_gamers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class Tables_for_gamersService : ITables_for_gamersService
{
    public Task AddTablesForGamersAsync(AddTables_for_gamersDTO tablesforgamers)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTablesForGamersAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<Tables_for_gamersDTO>> Filter(FilterParameters parametrs)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<Tables_for_gamersDTO>> GetPagedCategories(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<List<Tables_for_gamersDTO>> GetTablesForGamersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Tables_for_gamersDTO> GetTablesForGamersByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTablesForGamersAsync(UpdateTables_for_gamersDTO tablesforgamers)
    {
        throw new NotImplementedException();
    }
}
