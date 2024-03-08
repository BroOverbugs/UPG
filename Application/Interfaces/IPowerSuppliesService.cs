using DTOS.Power_supplies;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IPowerSuppliesService
{
    Task<List<PowerSuppliesDTO>> Filter(PowerSuppliesFIlter powerSuppliesfilter);
    Task<IEnumerable<PowerSuppliesDTO>> GetPowerSuppliesAsync();
    Task<PowerSuppliesDTO> GetPowerSuppliesByIdAsync(int id);
    Task AddPowerSuppliesAsync(AddPowerSuppliesDTO Powersupplies);
    Task UpdatePowerSuppliesAsync(UpdatePowerSuppliesDTO Powersupplies);
    Task DeletePowerSuppliesAsync(int id);
}
