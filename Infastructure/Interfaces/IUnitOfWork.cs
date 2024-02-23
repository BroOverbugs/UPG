namespace Infastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IHousingInterface Housing { get; }
    IKeyboardInterface Keyboard { get; }
    ILaptopInterface Laptop { get; }
    IMiceInterface Mice { get; }
    IMonitorInterface Monitor { get; }
    RAMInterface RAM { get; }
    MousePadsInterface Mouse_pads { get; }
    PowerSuppliesInterface Power_supplies { get; }
    Tables_for_gamersInterface Tables_For_Gamers { get; }
    IAccessoriesInterface Accessories { get; }
    Task SaveAsync();
}
