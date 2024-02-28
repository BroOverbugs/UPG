using DTOS.MiceDTOs;

namespace Application.Interfaces;

public interface IMiceService
{
    Task<List<MiceDto>> GetAllAsync();
    Task<MiceDto> GetByIdAsync(int id);
    void Create(AddMiceDto miceDto);
    void Update(UpdateMiceDto miceDto);
    void Delete(int id);
}
