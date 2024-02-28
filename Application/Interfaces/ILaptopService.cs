using DTOS.LaptopDTOs;

namespace Application.Interfaces;

public interface ILaptopService
{
    Task<List<LaptopDto>> GetAllAsync();
    Task<LaptopDto> GetByIdAsync(int id);
    Task Create(AddLaptopDto laptopDto);
    Task Update(UpdateLaptopDto laptopDto);
    Task Delete(int id);
}