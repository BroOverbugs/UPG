using DTOS.LaptopDTOs;

namespace Application.Interfaces;

public interface ILaptopService
{
    Task<List<LaptopDto>> GetAllAsync();
    Task<LaptopDto> GetByIdAsync(int id);
    void Create(AddLaptopDto laptopDto);
    void Update(UpdateLaptopDto laptopDto);
    void Delete(int id);
}
