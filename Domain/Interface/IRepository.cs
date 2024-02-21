using Domain.Entities;

namespace Domain.Interface;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
}
