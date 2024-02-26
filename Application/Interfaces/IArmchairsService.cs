using Domain.Entities;
using DTOS.ArmchairsDTOs;

namespace Application.Interfaces;

public interface IArmchairsService
{
    Task<IEnumerable<ArmchairsDTO>> GetArmchairsAsync();
    Task<ArmchairsDTO> GetArmchairsByIdAsync(int Id);
    Task AddArmchairsAsync(AddArmchairsDTO dto);
    Task UpdateArmchairsAsync(UpdateArmchairsDTO dto);
    Task DeleteArmchairsAsync(int Id);
}
