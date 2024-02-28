using DTOS.MonitorDTOs;

namespace Application.Interfaces;

public interface IMonitorService
{
    Task<List<MonitorDto>> GetAllAsync();
    Task<MonitorDto> GetByIdAsync(int id);
    void Create(AddMonitorDto monitorDto);
    void Update(UpdateMonitorDto monitorDto);
    void Delete(int id);
}