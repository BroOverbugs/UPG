using Domain.Entities;
using DTOS.CoolerDTOs;

namespace Application.Interfaces;

public interface ICoolerService
{
    Task<IEnumerable<CoolerDTO>> GetCoolersAsync();
    Task<CoolerDTO> GetCoolerByIdAsync(int Id);
    Task AddCoolerAsync(AddCoolerDTO coolerDTO);
    Task UpdateCoolerAsync(UpdateCoolerDTO coolerDTO);
    Task DeleteCoolerAsync(int Id);
}
