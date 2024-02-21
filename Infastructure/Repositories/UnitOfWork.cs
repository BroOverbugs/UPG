using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories;

public class UnitOfWork(AppDBContext dBContext) : IUnitOfWork
{
    private readonly AppDBContext _dBContext = dBContext;

    public void Dispose()
        => GC.SuppressFinalize(this);

    public Task SaveAsync()
        => _dBContext.SaveChangesAsync();
}
