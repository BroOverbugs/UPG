using DTOS.AccessoriesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccessoriesService
    {
        Task<List<AccessoriesDto>> GetAccessoriesAsync();
        Task<AccessoriesDto> GetAccessoriesByIdAsync(int id);
        Task AddAccessoriesAsync(AddAccessoriesDto addAccessoriesDto);
        Task UpdateAccessoriesAsync(UpdateAccessoriesDto updateAccessoriesDto);
        Task DeleteAccessoriesAsync(int id);
    }
}
