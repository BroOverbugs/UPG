using DTOS.LaptopDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface ILaptopService
{
    Task<List<LaptopDto>> GetAllAsync();
    Task<LaptopDto> GetByIdAsync(int id);
    Task<List<LaptopDto>> FilterAsync(LaptopFilter laptopFilter);
    Task Create(AddLaptopDto laptopDto);
    Task Update(UpdateLaptopDto laptopDto);
    Task Delete(int id);
}