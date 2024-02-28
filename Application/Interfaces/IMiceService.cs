using DTOS.MiceDTOs;

namespace Application.Interfaces;

public interface IMiceService
{
    Task<List<MiceDto>> GetAllAsync();
    Task<MiceDto> GetByIdAsync(int id);
    Task Create(AddMiceDto miceDto);
    Task Update(UpdateMiceDto miceDto);
    Task Delete(int id);
}