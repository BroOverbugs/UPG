using DTOS.HousingDTOs;

namespace Application.Interfaces;

public interface IHousingService
{
    Task<List<HousingDto>> GetAllAsync();
    Task<HousingDto> GetByIdAsync(int id);
    void Create(AddHousingDto housingDto);
    void Update(UpdateHousingDto housingDto);
    void Delete(int id);
}
