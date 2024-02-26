using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repositories
{
    public class ImageRepository(AppDBContext dBContext) : IImageInterface
    {
        private readonly AppDBContext _dBContext = dBContext;

        public void Add(Image entity)
        {
            _dBContext.Images.Add(entity);
        }

        public void Delete(int id)
        {
            var image = GetByIdAsync(id).Result;
            _dBContext.Images.Remove(image);
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
            => await _dBContext.Images.ToListAsync();

        public async Task<Image> GetByIdAsync(int id)
            => await _dBContext.Images.FirstOrDefaultAsync(i => i.Id == id);

        public void Update(Image entity)
        {
            _dBContext.Images.Update(entity);
        }
    }
}