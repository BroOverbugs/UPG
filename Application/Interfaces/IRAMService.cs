using DTOS.RAM;
using UPG.Core.Filters;

namespace Application.Interfaces;

public interface IRAMService
{
    Task<List<RAMDTO>> Filter(RAMFilter ramfilter);
    Task<IEnumerable<RAMDTO>> GetRAMAsync();
    Task<RAMDTO> GetRAMByIdAsync(int id);
    Task AddRAMAsync(AddRAMDTO ram);
    Task UpdateRAMAsync(UpdateRAMDTO ram);
    Task DeleteRAMAsync(int id);
}
