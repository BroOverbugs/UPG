using Domain.Entities;
using DTOS.ArmchairsDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IArmchairsService
{

    Task<List<ArmchairsDTO>> Filter(ArmchairsFilter filter);
    Task<IEnumerable<ArmchairsDTO>> GetArmchairsAsync();
    Task<ArmchairsDTO> GetArmchairsByIdAsync(int Id);
    Task AddArmchairsAsync(AddArmchairsDTO dto);
    Task UpdateArmchairsAsync(UpdateArmchairsDTO dto);
    Task DeleteArmchairsAsync(int Id);
}
