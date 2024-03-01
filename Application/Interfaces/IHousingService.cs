using UPG.Core.Filters;
using DTOS.HousingDTOs;

namespace Application.Interfaces;

public interface IHousingService
{
    Task<List<HousingDto>> GetAllAsync();
    Task<HousingDto> GetByIdAsync(int id);
    Task Create(AddHousingDto housingDto);
    Task Update(UpdateHousingDto housingDto);
    Task<List<HousingDto>> FilterAsync(HousingFilter housingFilter);
    Task Delete(int id);
}
