using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.RAM;
using DTOS.Tables_for_gamers;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class Tables_for_gamersService : ITables_for_gamersService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public Tables_for_gamersService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task AddTablesForGamersAsync(AddTables_for_gamersDTO tablesforgamers)
    {
        var config = _mapper.Map<Tables_for_gamers>(tablesforgamers);
        _unitOfWork.Tables_For_Gamers.Add(config);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteTablesForGamersAsync(int id)
    {
        _unitOfWork.Tables_For_Gamers.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<PagedList<Tables_for_gamersDTO>> Filter(FilterParameters parametrs)
    {
        var list = await _unitOfWork.Tables_For_Gamers.GetAllAsync();

        // Filter by title
        if (parametrs.title is not "")
        {
            list = list.Where(book => book.Name.ToLower()
                       .Contains(parametrs.Title.ToLower()));
        }

        // Filter by Price
        list = list.Where(book => book.Price >= parametrs.minPrice &&
                                      book.Price <= parametrs.maxPrice);

        var dtos = list.Select(book => _mapper.Map<Tables_for_gamersDTO>(book)).ToList();

        // Order by title
        if (parametrs.orderByTitle)
        {
            dtos = dtos.OrderBy(book => book.Name).ToList();
        }
        else
        {
            dtos = dtos.OrderByDescending(book => book.Name).ToList();
        }

        PagedList<Tables_for_gamersDTO> pagedList = new(dtos, dtos.Count,
                                                          parametrs.PageNumber, parametrs.pageSize);

        return pagedList.ToPagedList(dtos, parametrs.PageSize, parametrs.PageNumber);
    }

    public async Task<PagedList<Tables_for_gamersDTO>> GetPagedCategories(int pageSize, int pageNumber)
    {
        var dtos = await GetTablesForGamersAsync();
        PagedList<Tables_for_gamersDTO> pagedList = new(dtos,
                                                          dtos.Count(),
                                                          pageNumber,
                                                          pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<IEnumerable<Tables_for_gamersDTO>> GetTablesForGamersAsync()
    {
        var config = await _unitOfWork.Tables_For_Gamers.GetAllAsync();
        var glaive = _mapper.Map<IEnumerable<Tables_for_gamersDTO>>(config);
        return glaive;
    }

    public async Task<Tables_for_gamersDTO> GetTablesForGamersByIdAsync(int id)
    {
        var config = await _unitOfWork.Tables_For_Gamers.GetByIdAsync(id);
        return _mapper.Map<Tables_for_gamersDTO>(config);
    }

    public async Task UpdateTablesForGamersAsync(UpdateTables_for_gamersDTO tablesforgamers)
    {
        var config = _mapper.Map<Tables_for_gamers>(tablesforgamers);
        _unitOfWork.Tables_For_Gamers.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
