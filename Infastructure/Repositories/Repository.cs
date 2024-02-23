using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repositories;

public class Repository<T>(AppDBContext dBContext)
    : IRepository<T> where T : BaseEntity
{
    private DbSet<T> _DbSet = dBContext.Set<T>();

    public void Add(T entity)
        =>_DbSet.Add(entity);

    public void Delete(int id)
    {
        var entity = _DbSet.AsNoTracking().FirstOrDefault(c => c.Id == id);   
        _DbSet.Remove(entity!);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _DbSet.AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
        => await _DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

    public void Update(T entity)
        => _DbSet.Update(entity);
}
