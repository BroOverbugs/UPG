using Application.Helpers;
using Domain.Entities;
using DTOS.Power_supplies;

namespace Application.Interfaces;

public interface IPower_suppliesService
{
    Task<PagedList<Power_suppliesDTO>> Filter(FilterParameters parametrs);
    Task<PagedList<Power_suppliesDTO>> GetPagedPowerSupplies(int pageSize, int pageNumber);
    Task<List<Power_suppliesDTO>> GetPowerSuppliesAsync();
    Task<Power_suppliesDTO> GetPowerSuppliesByIdAsync(int id);
    Task AddPowerSuppliesAsync(AddPower_suppliesDTO newCategory);
    Task UpdatePowerSuppliesAsync(UpdatePower_suppliesDTO categoryDto);
    Task DeletePowerSuppliesAsync(int id);
}
