using Application.Helpers;
using Domain.Entities;
using DTOS.Power_supplies;

namespace Application.Interfaces;

public interface IPowerSuppliesService
{
    Task<PagedList<PowerSuppliesDTO>> Filter(FilterParameters parametrs);
    Task<PagedList<PowerSuppliesDTO>> GetPagedPowerSupplies(int pageSize, int pageNumber);
    Task<IEnumerable<PowerSuppliesDTO>> GetPowerSuppliesAsync();
    Task<PowerSuppliesDTO> GetPowerSuppliesByIdAsync(int id);
    Task AddPowerSuppliesAsync(AddPowerSuppliesDTO Powersupplies);
    Task UpdatePowerSuppliesAsync(UpdatePowerSuppliesDTO Powersupplies);
    Task DeletePowerSuppliesAsync(int id);
}
