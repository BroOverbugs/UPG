using DTOS.KeyboardDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IKeyboardService
{
    Task<List<KeyboardDto>> GetAllAsync();
    Task<KeyboardDto> GetByIdAsync(int id);
    Task<List<KeyboardDto>> FilterAsync(KeyboardFilter keyboardFilter);
    Task Create(AddKeyboardDto KeyboardDto);
    Task Update(UpdateKeyboardDto KeyboardDto);
    Task Delete(int id);
}
