using DTOS.HeadphonesDTOs;

namespace Application.Interfaces;

public interface IHeadphonesService
{
    Task<IEnumerable<HeadphonesDTO>> GetHeadphonesAsync();
    Task<HeadphonesDTO> GetHeadphonesByIdAsync(int Id);
    Task AddHeadphonesAsync(AddHeadphonesDTO dto);
    Task UpdateHeadphonesAsync(UpdateHeadphonesDTO dto);
    Task DeleteHeadphonesAsync(int Id);
}
