namespace Infastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
}
