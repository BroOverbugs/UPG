using Application.Helpers;
using DTOS.AccessoriesDtos;
using UPG.Core.Filters;

namespace Application.Interfaces
{ 
    public interface IAccessoriesService
    {
        Task<IEnumerable<AccessoriesDto>> GetAccessoriesAsync();
        Task<AccessoriesDto> GetAccessoriesByIdAsync(int id);
        Task AddAccessoriesAsync(AddAccessoriesDto addAccessoriesDto);
        Task UpdateAccessoriesAsync(UpdateAccessoriesDto updateAccessoriesDto);
        Task<List<AccessoriesDto>> FilterAsync(AccessoriesFilter accessoriesFilter);
        Task DeleteAccessoriesAsync(int id);
    }
}
