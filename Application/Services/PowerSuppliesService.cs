using Application.Common.Exceptions;
using Application.Common.Validators.ElyorbekModels.MousePadsValidators;
using Application.Common.Validators.ElyorbekModels.PowerSuppliesValidators;
using Application.Common.Validators.HousingValidators;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.HousingDTOs;
using DTOS.Power_supplies;
using FluentValidation;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class PowerSuppliesService : IPowerSuppliesService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IS3Interface _s3Interface;
    public PowerSuppliesService(IMapper mapper,IUnitOfWork unitOfWork, IS3Interface s3Interface)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _s3Interface = s3Interface;
    }
    public async Task AddPowerSuppliesAsync(AddPowerSuppliesDTO Powersupplies)
    {
        if (Powersupplies == null) throw new ArgumentNullException("Power Supplies was null!");

        var validator = new AddPowerSuppliesDTOValidator();
        var validationResult = validator.Validate(Powersupplies);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }
        var config = _mapper.Map<PowerSupplies>(Powersupplies);
        _unitOfWork.Power_supplies.Add(config);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeletePowerSuppliesAsync(int id)
    {
        var power = GetPowerSuppliesByIdAsync(id).Result;
        if (power == null) throw new NotFoundException("Power Supplies not found!");


        var images = power.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
        }
        _unitOfWork.Power_supplies.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<PagedList<PowerSuppliesDTO>> Filter(FilterParameters parametrs)
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

        var dtos = list.Select(book => _mapper.Map<PowerSuppliesDTO>(book)).ToList();

        // Order by title
        if (parametrs.orderByTitle)
        {
            dtos = dtos.OrderBy(book => book.Name).ToList();
        }
        else
        {
            dtos = dtos.OrderByDescending(book => book.Name).ToList();
        }

        PagedList<PowerSuppliesDTO> pagedList = new(dtos, dtos.Count(),
                                                          parametrs.PageNumber, parametrs.pageSize);

        return pagedList.ToPagedList(dtos, parametrs.PageSize, parametrs.PageNumber);
    }

    public async Task<PagedList<PowerSuppliesDTO>> GetPagedPowerSupplies(int pageSize, int pageNumber)
    {
        var dtos = await GetPowerSuppliesAsync();
        PagedList<PowerSuppliesDTO> pagedList = new(dtos,
                                                          dtos.Count(),
                                                          pageNumber,
                                                          pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<IEnumerable<PowerSuppliesDTO>> GetPowerSuppliesAsync()
    {
        var config =  await _unitOfWork.Power_supplies.GetAllAsync();
        var glaive = _mapper.Map<IEnumerable<PowerSuppliesDTO>>(config);
        return glaive;
    }

    public async Task<PowerSuppliesDTO> GetPowerSuppliesByIdAsync(int id)
    {
        var config = await _unitOfWork.Power_supplies.GetByIdAsync(id);
        if (config == null) throw new NotFoundException("Power Supply Not Found!");
        return _mapper.Map<PowerSuppliesDTO>(config);
    }

    public async Task UpdatePowerSuppliesAsync(UpdatePowerSuppliesDTO Powersupplies)
    {
        var power = await _unitOfWork.Power_supplies.GetByIdAsync(Powersupplies.ID);
        if (power == null) throw new NotFoundException("Power Supply not found!");


        var validator = new UpdatePowerSuppliesDTOValidator();
        var validationResult = validator.Validate(Powersupplies);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = power.ImageUrls.Except(Powersupplies.ImageUrls);

        foreach (var url in forDelete)
        {
            await _s3Interface.DeleteFileAsync(url.Split('/')[^1]);
        }
        var config = _mapper.Map<PowerSupplies>(Powersupplies);
        _unitOfWork.Power_supplies.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
