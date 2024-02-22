using Application.Helpers;
using Domain.Entities;
using DTOS.Power_supplies;

namespace Application.Interfaces;

public interface IPower_suppliesService
{
    Task<PagedList<Power_suppliesDTO>> Filter(FilterParameters parametrs);
    Task<PagedList<Power_suppliesDTO>> GetPagedPowerSupplies(int pageSize, int pageNumber);
    Task<IEnumerable<Power_suppliesDTO>> GetPowerSuppliesAsync();
    Task<Power_suppliesDTO> GetPowerSuppliesByIdAsync(int id);
    Task AddPowerSuppliesAsync(AddPower_suppliesDTO Powersupplies);
    Task UpdatePowerSuppliesAsync(UpdatePower_suppliesDTO Powersupplies);
    Task DeletePowerSuppliesAsync(int id);
}
