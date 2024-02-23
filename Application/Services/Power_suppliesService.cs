using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.Power_supplies;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class Power_suppliesService : IPower_suppliesService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public Power_suppliesService(IMapper mapper,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task AddPowerSuppliesAsync(AddPower_suppliesDTO Powersupplies)
    {
        var config = _mapper.Map<Power_supplies>(Powersupplies);
        _unitOfWork.Power_supplies.Add(config);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeletePowerSuppliesAsync(int id)
    {
        _unitOfWork.Power_supplies.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<PagedList<Power_suppliesDTO>> Filter(FilterParameters parametrs)
    {
        var list = await _unitOfWork.Power_supplies.GetAllAsync();

        // Filter by title
        if (parametrs.title is not "")
        {
            list = list.Where(book => book.Name.ToLower()
                       .Contains(parametrs.Title.ToLower()));
        }

        // Filter by Price
        list = list.Where(book => book.Price >= parametrs.minPrice &&
                                      book.Price <= parametrs.maxPrice);

        var dtos = list.Select(book => _mapper.Map<Power_suppliesDTO>(book)).ToList();

        // Order by title
        if (parametrs.orderByTitle)
        {
            dtos = dtos.OrderBy(book => book.Name).ToList();
        }
        else
        {
            dtos = dtos.OrderByDescending(book => book.Name).ToList();
        }

        PagedList<Power_suppliesDTO> pagedList = new(dtos, dtos.Count,
                                                          parametrs.PageNumber, parametrs.pageSize);

        return pagedList.ToPagedList(dtos, parametrs.PageSize, parametrs.PageNumber);
    }

    public async Task<PagedList<Power_suppliesDTO>> GetPagedPowerSupplies(int pageSize, int pageNumber)
    {
        var dtos = await GetPowerSuppliesAsync();
        PagedList<Power_suppliesDTO> pagedList = new(dtos,
                                                          dtos.Count(),
                                                          pageNumber,
                                                          pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<IEnumerable<Power_suppliesDTO>> GetPowerSuppliesAsync()
    {
        var config =  await _unitOfWork.Power_supplies.GetAllAsync();
        var glaive = _mapper.Map<IEnumerable<Power_suppliesDTO>>(config);
        return glaive;
    }

    public async Task<Power_suppliesDTO> GetPowerSuppliesByIdAsync(int id)
    {
        var config = await _unitOfWork.Power_supplies.GetByIdAsync(id);
        return _mapper.Map<Power_suppliesDTO>(config);
    }

    public async Task UpdatePowerSuppliesAsync(UpdatePower_suppliesDTO Powersupplies)
    {
        var config = _mapper.Map<Power_supplies>(Powersupplies);
        _unitOfWork.Power_supplies.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
