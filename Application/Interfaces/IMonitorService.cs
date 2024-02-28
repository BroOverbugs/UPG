using DTOS.MonitorDTOs;

namespace Application.Interfaces;

public interface IMonitorService
{
    Task<List<MonitorDto>> GetAllAsync();
    Task<MonitorDto> GetByIdAsync(int id);
    Task Create(AddMonitorDto monitorDto);
    Task Update(UpdateMonitorDto monitorDto);
    Task Delete(int id);
}