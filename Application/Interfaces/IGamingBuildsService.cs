using DTOS.GamingBuildsDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IGamingBuildsService
{
    Task<List<GamingBuildsDTO>> Filter(GamingBuildsFilter filter);
    Task<IEnumerable<GamingBuildsDTO>> GetGamingBuildsAsync();
    Task<GamingBuildsDTO> GetGamingBuildsByIdAsync(int id);
    Task AddGamingBuildsAsync(AddGamingBuildsDTO dto);
    Task UpdateGamingBuildsAsync(UpdateGamingBuildsDTO dto);
    Task DeleteGamingBuildsAsync(int id);
}
