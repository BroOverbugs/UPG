 using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.Power_supplies;
using DTOS.RAM;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class RAMService : IRAMService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public RAMService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task AddRAMAsync(AddRAMDTO ram)
    {
        var config = _mapper.Map<RAM>(ram);
        _unitOfWork.RAM.Add(config);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteRAMAsync(int id)
    {
        _unitOfWork.RAM.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<PagedList<RAMDTO>> Filter(FilterParameters parametrs)
    {
        var list = await _unitOfWork.RAM.GetAllAsync();

        // Filter by title
        if (parametrs.title is not "")
        {
            list = list.Where(book => book.Name.ToLower()
                       .Contains(parametrs.Title.ToLower()));
        }

        // Filter by Price
        list = list.Where(book => book.Price >= parametrs.minPrice &&
                                      book.Price <= parametrs.maxPrice);

        var dtos = list.Select(book => _mapper.Map<RAMDTO>(book)).ToList();

        // Order by title
        if (parametrs.orderByTitle)
        {
            dtos = dtos.OrderBy(book => book.Name).ToList();
        }
        else
        {
            dtos = dtos.OrderByDescending(book => book.Name).ToList();
        }

        PagedList<RAMDTO> pagedList = new(dtos, dtos.Count,
                                                          parametrs.PageNumber, parametrs.pageSize);

        return pagedList.ToPagedList(dtos, parametrs.PageSize, parametrs.PageNumber);
    }

    public async Task<IEnumerable<RAMDTO>> GetRAMAsync()
    {
        var config = await _unitOfWork.RAM.GetAllAsync();
        var glaive = _mapper.Map<IEnumerable<RAMDTO>>(config);
        return glaive;
    }

    public async Task<RAMDTO> GetRAMByIdAsync(int id)
    {
        var config = await _unitOfWork.RAM.GetByIdAsync(id);
        return _mapper.Map<RAMDTO>(config);
    }

    public async Task<PagedList<RAMDTO>> GetPagedRAMs(int pageSize, int pageNumber)
    {
        var dtos = await GetRAMAsync();
        PagedList<RAMDTO> pagedList = new(dtos,
                                                          dtos.Count(),
                                                          pageNumber,
                                                          pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task UpdateRAMAsync(UpdateRAMDTO ram)
    {
        var config = _mapper.Map<RAM>(ram);
        _unitOfWork.RAM.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
