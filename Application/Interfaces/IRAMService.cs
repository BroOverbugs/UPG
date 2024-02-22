using Application.Helpers;
using DTOS.Mouse_pads;
using DTOS.RAM;

namespace Application.Interfaces;

public interface IRAMService
{
    Task<PagedList<RAMDTO>> Filter(FilterParameters parametrs);
    Task<PagedList<RAMDTO>> GetPagedRAMs(int pageSize, int pageNumber);
    Task<IEnumerable<RAMDTO>> GetRAMAsync();
    Task<RAMDTO> GetRAMByIdAsync(int id);
    Task AddRAMAsync(AddRAMDTO ram);
    Task UpdateRAMAsync(UpdateRAMDTO ram);
    Task DeleteRAMAsync(int id);
}
