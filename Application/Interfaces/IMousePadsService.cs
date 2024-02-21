using Application.Helpers;
using DTOS.Mouse_pads;
using DTOS.Power_supplies;

namespace Application.Interfaces;

public interface IMousePadsService
{
    Task<PagedList<Mouse_padsDTO>> Filter(FilterParameters parametrs);
    Task<PagedList<Mouse_padsDTO>> GetPagetMousePads(int pageSize, int pageNumber);
    Task<List<Mouse_padsDTO>> GetMousePadsAsync();
    Task<Mouse_padsDTO> GetMousePadByIdAsync(int id);
    Task AddMousePadsAsync(AddMouse_padsDTO newCategory);
    Task UpdateMousePadsAsync(UpdateMouse_padsDTO categoryDto);
    Task DeleteMousePadsAsync(int id);
}
