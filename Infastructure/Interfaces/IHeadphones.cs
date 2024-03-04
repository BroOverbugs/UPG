using Domain.Entities;
using Infastructure.Interface;
using UPG.Core.Filters;

namespace Infastructure.Interfaces;

public interface IHeadphones : IRepository<Headphones>
{
    Task<List<Headphones>> GetFilteredHeadphonesAsync(HeadphonesFilter filter);
}
