using DTOS.HeadphonesDTOs;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IHeadphonesService
{
    Task<List<HeadphonesDTO>> Filter(HeadphonesFilter filter);
    Task<IEnumerable<HeadphonesDTO>> GetHeadphonesAsync();
    Task<HeadphonesDTO> GetHeadphonesByIdAsync(int Id);
    Task AddHeadphonesAsync(AddHeadphonesDTO dto);
    Task UpdateHeadphonesAsync(UpdateHeadphonesDTO dto);
    Task DeleteHeadphonesAsync(int Id);
}
