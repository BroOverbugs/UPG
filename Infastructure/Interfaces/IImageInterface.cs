using Domain.Entities;
using Infastructure.Interface;

namespace Infastructure.Interfaces
{
    public interface IImageInterface
    {
        Task<IEnumerable<Image>> GetAllAsync();
        Task<Image> GetByIdAsync(int id);
        void Add(Image entity);
        void Update(Image entity);
        void Delete(int id);
    }
}
