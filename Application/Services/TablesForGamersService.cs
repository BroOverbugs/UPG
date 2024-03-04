using Application.Common.Exceptions;
using Application.Common.Validators.ElyorbekModels.TablesForGamersValidators;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.MonitorDTOs;
using DTOS.Tables_for_gamers;
using Infastructure.Interfaces;
using UPG.Core.Filters;

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

    public async Task<List<TablesForGamersDTO>> Filter(TablesForGamersFilter tablesforgamersfilter)
    {
        var monitors = await _unitOfWork.Tables_For_Gamers.GetFilteredTablesForGamers(tablesforgamersfilter);

        return monitors.Select(i => (TablesForGamersDTO)i).ToList();
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
        var power = await _unitOfWork.Tables_For_Gamers.GetByIdAsync(tablesforgamers.ID);
        if (power == null) throw new NotFoundException("RAM not found!");


        var validator = new UpdateTablesForGamersDTOValidator();
        var validationResult = validator.Validate(tablesforgamers);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = power.ImageUrls.Except(tablesforgamers.ImageUrls);

        foreach (var url in forDelete)
        {
            await _s3Interface.DeleteFileAsync(url.Split('/')[^1]);
        }
        var config = _mapper.Map<TablesForGamers>(tablesforgamers);
        _unitOfWork.Tables_For_Gamers.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
