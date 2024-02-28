using DTOS.KeyboardDTOs;

namespace Application.Interfaces;

public interface IKeyboardService
{
    Task<List<KeyboardDto>> GetAllAsync();
    Task<KeyboardDto> GetByIdAsync(int id);
    void Create(AddKeyboardDto KeyboardDto);
    void Update(UpdateKeyboardDto KeyboardDto);
    void Delete(int id);
}
