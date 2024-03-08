using DTOS.MousePadDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IMousePadsService
{
    Task<List<MousePadsDTO>> Filter(MousePadsFilter mousepadsfilter);
    Task<IEnumerable<MousePadsDTO>> GetMousePadsAsync();
    Task<MousePadsDTO> GetMousePadByIdAsync(int id);
    Task AddMousePadsAsync(AddMousePadsDTO mousepads);
    Task UpdateMousePadsAsync(UpdateMousePadsDTO  mousepads);
    Task DeleteMousePadsAsync(int id);
}
