using DTOS.DrivesDTOs;

namespace Application.Interfaces;

public interface IDrivesService
{
    Task<IEnumerable<DrivesDTO>> GetDrivesAllAsync();
    Task<DrivesDTO> GetDrivesByIdAsync(int id);
    Task AddDrivesAsync(AddDrivesDTO drivesDTO);
    Task UpdateDrivesAsync(UpdateDrivesDTO drivesDTO);
    Task DeleteDrivesAsync(int id);
}
