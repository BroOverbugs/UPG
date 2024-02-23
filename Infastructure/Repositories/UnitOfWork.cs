using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories;

public class UnitOfWork(AppDBContext dBContext) : IUnitOfWork
{
    private readonly AppDBContext _dBContext = dBContext;

    public IHousingInterface Housing => new HousingRepository(_dBContext);

    public IKeyboardInterface Keyboard => new KeyboardRepository(_dBContext);

    public ILaptopInterface Laptop => new LaptopRepository(_dBContext);

    public IMiceInterface Mice => new MiceRepository(_dBContext);

    public IMonitorInterface Monitor => new MonitorRepository(_dBContext);
    
    public IAccessoriesInterface Accessories => new AccessoriesRepository(_dBContext);

    public RAMInterface RAM => new RAMRepository(_dBContext);

    public MousePadsInterface Mouse_pads => new MousePadsRepository(_dBContext);

    public PowerSuppliesInterface Power_supplies => new PowerSuppliesRepository(_dBContext);

    public TablesForGamersInterface Tables_For_Gamers => new TablesForGamersRepository(_dBContext);

    public void Dispose()
        => GC.SuppressFinalize(this);

    public Task SaveAsync()
        => _dBContext.SaveChangesAsync();
}
