using DTOS.MiceDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IMiceService
{
    Task<List<MiceDto>> GetAllAsync();
    Task<MiceDto> GetByIdAsync(int id);
    Task<List<MiceDto>> FilterAsync(MiceFilter miceFilter);
    Task Create(AddMiceDto miceDto);
    Task Update(UpdateMiceDto miceDto);
    Task Delete(int id);
}