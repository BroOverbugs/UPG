using Application.Helpers;
using Domain.Entities;
using DTOS.Mouse_pads;
using DTOS.Tables_for_gamers;

namespace Application.Interfaces;

public interface ITablesForGamersService
{
    
    Task<PagedList<TablesForGamersDTO>> Filter(FilterParameters parametrs);
    Task<PagedList<TablesForGamersDTO>> GetPagedCategories(int pageSize, int pageNumber);
    Task<IEnumerable<TablesForGamersDTO>> GetTablesForGamersAsync();
    Task<TablesForGamersDTO> GetTablesForGamersByIdAsync(int id);
    Task AddTablesForGamersAsync(AddTablesForGamersDTO tablesforgamers);
    Task UpdateTablesForGamersAsync(UpdateTablesForGamersDTO tablesforgamers);
    Task DeleteTablesForGamersAsync(int id);
}
