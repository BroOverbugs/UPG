using DTOS.MiceDTOs;
using DTOS.MonitorDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IMonitorService
{
    Task<List<MonitorDto>> GetAllAsync();
    Task<MonitorDto> GetByIdAsync(int id);
    Task<List<MonitorDto>> FilterAsync(MonitorFilter monitorFilter);
    Task Create(AddMonitorDto monitorDto);
    Task Update(UpdateMonitorDto monitorDto);
    Task Delete(int id);
}