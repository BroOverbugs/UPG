using Application.Helpers;
using Domain.Entities;
using DTOS.Mouse_pads;
using DTOS.Tables_for_gamers;

namespace Application.Interfaces;

public interface ITables_for_gamersService
{
    
    Task<PagedList<Tables_for_gamersDTO>> Filter(FilterParameters parametrs);
    Task<PagedList<Tables_for_gamersDTO>> GetPagedCategories(int pageSize, int pageNumber);
    Task<List<Tables_for_gamersDTO>> GetTablesForGamersAsync();
    Task<Tables_for_gamersDTO> GetTablesForGamersByIdAsync(int id);
    Task AddTablesForGamersAsync(AddTables_for_gamersDTO newCategory);
    Task UpdateTablesForGamersAsync(UpdateTables_for_gamersDTO categoryDto);
    Task DeleteTablesForGamersAsync(int id);
}
