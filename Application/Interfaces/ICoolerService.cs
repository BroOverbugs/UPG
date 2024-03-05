using Domain.Entities;
using DTOS.CoolerDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface ICoolerService
{
    Task<List<CoolerDTO>> Filter(CoolerFilter filter);
    Task<IEnumerable<CoolerDTO>> GetCoolersAsync();
    Task<CoolerDTO> GetCoolerByIdAsync(int Id);
    Task AddCoolerAsync(AddCoolerDTO coolerDTO);
    Task UpdateCoolerAsync(UpdateCoolerDTO coolerDTO);
    Task DeleteCoolerAsync(int Id);
}
