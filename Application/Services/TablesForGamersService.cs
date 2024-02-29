using Application.Common.Exceptions;
using Application.Common.Validators.ElyorbekModels.TablesForGamersValidators;
using Application.Common.Validators.HousingValidators;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.HousingDTOs;
using DTOS.RAM;
using DTOS.Tables_for_gamers;
using FluentValidation;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class TablesForGamersService : ITablesForGamersService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IS3Interface _s3Interface;
    public TablesForGamersService(IMapper mapper, IUnitOfWork unitOfWork, IS3Interface s3Interface)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _s3Interface = s3Interface;
    }
    public async Task AddTablesForGamersAsync(AddTablesForGamersDTO tablesforgamers)
    {
        if (tablesforgamers == null) throw new ArgumentNullException("Housing was null!");

        var validator = new AddTablesForGamersDTOValidator();
        var validationResult = validator.Validate(tablesforgamers);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }
        var config = _mapper.Map<TablesForGamers>(tablesforgamers);
        _unitOfWork.Tables_For_Gamers.Add(config);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteTablesForGamersAsync(int id)
    {
        var TFG = GetTablesForGamersByIdAsync(id).Result;
        if (TFG == null) throw new NotFoundException("Table not found!");


        var images = TFG.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
        }
        _unitOfWork.Tables_For_Gamers.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<PagedList<TablesForGamersDTO>> Filter(FilterParameters parametrs)
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

        var dtos = list.Select(book => _mapper.Map<TablesForGamersDTO>(book)).ToList();

        // Order by title
        if (parametrs.orderByTitle)
        {
            dtos = dtos.OrderBy(book => book.Name).ToList();
        }
        else
        {
            dtos = dtos.OrderByDescending(book => book.Name).ToList();
        }

        PagedList<TablesForGamersDTO> pagedList = new(dtos, dtos.Count(),
                                                          parametrs.PageNumber, parametrs.pageSize);

        return pagedList.ToPagedList(dtos, parametrs.PageSize, parametrs.PageNumber);
    }

    public async Task<PagedList<TablesForGamersDTO>> GetPagedCategories(int pageSize, int pageNumber)
    {
        var dtos = await GetTablesForGamersAsync();
        PagedList<TablesForGamersDTO> pagedList = new(dtos,
                                                          dtos.Count(),
                                                          pageNumber,
                                                          pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<IEnumerable<TablesForGamersDTO>> GetTablesForGamersAsync()
    {
        var config = await _unitOfWork.Tables_For_Gamers.GetAllAsync();
        var glaive = _mapper.Map<IEnumerable<TablesForGamersDTO>>(config);
        return glaive;
    }

    public async Task<TablesForGamersDTO> GetTablesForGamersByIdAsync(int id)
    {
        var config = await _unitOfWork.Tables_For_Gamers.GetByIdAsync(id);
        if (config == null) throw new NotFoundException("Table Not Found!");
        return _mapper.Map<TablesForGamersDTO>(config);
    }

    public async Task UpdateTablesForGamersAsync(UpdateTablesForGamersDTO tablesforgamers)
    {
        var TFG = await _unitOfWork.Housing.GetByIdAsync(tablesforgamers.ID);
        if (TFG == null) throw new NotFoundException("Table not found!");


        var validator = new UpdateTablesForGamersDTOValidator();
        var validationResult = validator.Validate(tablesforgamers);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = TFG.ImageUrls.Except(tablesforgamers.ImageUrls);

        foreach (var imageUrl in forDelete)
        {
            await _s3Interface.DeleteFileAsync(imageUrl.Split('/')[^1]);
        }
        var config = _mapper.Map<TablesForGamers>(tablesforgamers);
        _unitOfWork.Tables_For_Gamers.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
