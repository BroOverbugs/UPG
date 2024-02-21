using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repository;

public class Repository<T>(AppDBContext dBContext)
    : IRepository<T> where T : BaseEntity
{
    private DbSet<T> _DbSet = dBContext.Set<T>();

    public void Add(T entity)
        => _DbSet.Add(entity);

    public void Delete(int id)
    {
        var entity = _DbSet.AsNoTracking().FirstOrDefault(c => c.ID == id);   
        _DbSet.Remove(entity!);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _DbSet.AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
        => await _DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.ID == id);

    public void Update(T entity)
        => _DbSet.Update(entity);
}
