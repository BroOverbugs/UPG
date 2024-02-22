namespace Infastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IHousingInterface Housing { get; }
    IKeyboardInterface Keyboard { get; }
    ILaptopInterface Laptop { get; }
    IMiceInterface Mice { get; }
    IMonitorInterface Monitor { get; }
    IAccessoriesInterface Accessories { get; }
    Task SaveAsync();
}
