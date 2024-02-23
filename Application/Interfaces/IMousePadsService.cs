using Application.Helpers;
using DTOS.Mouse_pads;
using DTOS.Power_supplies;

namespace Application.Interfaces;

public interface IMousePadsService
{
    Task<PagedList<MousePadsDTO>> Filter(FilterParameters parametrs);
    Task<PagedList<MousePadsDTO>> GetPagetMousePads(int pageSize, int pageNumber);
    Task<IEnumerable<MousePadsDTO>> GetMousePadsAsync();
    Task<MousePadsDTO> GetMousePadByIdAsync(int id);
    Task AddMousePadsAsync(AddMousePadsDTO mousepads);
    Task UpdateMousePadsAsync(UpdateMousePadsDTO  mousepads);
    Task DeleteMousePadsAsync(int id);
}
