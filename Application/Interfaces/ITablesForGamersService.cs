using DTOS.Tables_for_gamers;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface ITablesForGamersService
{

    Task<List<TablesForGamersDTO>> Filter(TablesForGamersFilter tablesforgamersfilter);
    Task<IEnumerable<TablesForGamersDTO>> GetTablesForGamersAsync();
    Task<TablesForGamersDTO> GetTablesForGamersByIdAsync(int id);
    Task AddTablesForGamersAsync(AddTablesForGamersDTO tablesforgamers);
    Task UpdateTablesForGamersAsync(UpdateTablesForGamersDTO tablesforgamers);
    Task DeleteTablesForGamersAsync(int id);
}
