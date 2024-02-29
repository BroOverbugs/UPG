using Domain.Entities;
using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface IKeyboardInterface : IRepository<Keyboard>
{
    Task<List<Keyboard>> GetFilteredKeyboard(KeyboardFilter filter);
}
