using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories
{
    public class KeyboardRepository(AppDBContext dBContext) : Repository<Keyboard>(dBContext), IKeyboardInterface
    {
    }
}