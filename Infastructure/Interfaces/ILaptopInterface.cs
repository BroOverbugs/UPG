using Domain.Entities;
using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface ILaptopInterface : IRepository<Laptop>
{
    Task<List<Laptop>> GetFilteredLaptop(LaptopFilter filter);
}
