using DTOS.KeyboardDTOs;

namespace Application.Interfaces;

public interface IKeyboardService
{
    Task<List<KeyboardDto>> GetAllAsync();
    Task<KeyboardDto> GetByIdAsync(int id);
    Task Create(AddKeyboardDto KeyboardDto);
    Task Update(UpdateKeyboardDto KeyboardDto);
    Task Delete(int id);
}
