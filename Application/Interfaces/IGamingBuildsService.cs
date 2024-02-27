using DTOS.GamingBuildsDTOs;

namespace Application.Interfaces;

public interface IGamingBuildsService
{
    Task<IEnumerable<GamingBuildsDTO>> GetGamingBuildsAsync();
    Task<GamingBuildsDTO> GetGamingBuildsByIdAsync(int id);
    Task AddGamingBuildsAsync(AddGamingBuildsDTO dto);
    Task UpdateGamingBuildsAsync(UpdateGamingBuildsDTO dto);
    Task DeleteGamingBuildsAsync(int id);
}
