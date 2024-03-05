using DTOS.DrivesDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IDrivesService
{
    Task<List<DrivesDTO>> Filter(DrivesFilter filter);
    Task<IEnumerable<DrivesDTO>> GetDrivesAllAsync();
    Task<DrivesDTO> GetDrivesByIdAsync(int id);
    Task AddDrivesAsync(AddDrivesDTO drivesDTO);
    Task UpdateDrivesAsync(UpdateDrivesDTO drivesDTO);
    Task DeleteDrivesAsync(int id);
}
