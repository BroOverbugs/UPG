﻿namespace Infastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IArmchairs Armchairs { get; }
    ICooler Cooler { get; }
    IDrives Drives { get; }
    IGamingBuilds GamingBuilds { get; }
    IHeadphones Headphones { get; }
    IHousingInterface Housing { get; }
    IKeyboardInterface Keyboard { get; }
    ILaptopInterface Laptop { get; }
    IMiceInterface Mice { get; }
    IMonitorInterface Monitor { get; }
    RAMInterface RAM { get; }
    MousePadsInterface Mouse_pads { get; }
    PowerSuppliesInterface Power_supplies { get; }
    TablesForGamersInterface Tables_For_Gamers { get; }
    IAccessoriesInterface Accessories { get; }
    Task<int> SaveAsync();
}
