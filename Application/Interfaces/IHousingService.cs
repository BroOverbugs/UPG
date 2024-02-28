using DTOS.HousingDTOs;

namespace Application.Interfaces;

public interface IHousingService
{
    Task<List<HousingDto>> GetAllAsync();
    Task<HousingDto> GetByIdAsync(int id);
    Task Create(AddHousingDto housingDto);
    Task Update(UpdateHousingDto housingDto);
    Task Delete(int id);
}
