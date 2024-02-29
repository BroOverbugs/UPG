using Application.Common.Exceptions;
using Application.Common.Validators.ElyorbekModels.RAMValidators;
using Application.Common.Validators.HousingValidators;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.HousingDTOs;
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
    private readonly IS3Interface _s3Interface;
    public RAMService(IMapper mapper, IUnitOfWork unitOfWork, IS3Interface s3Interface)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _s3Interface = s3Interface;
    }
    public async Task AddRAMAsync(AddRAMDTO ram)
    {
        if (ram == null) throw new ArgumentNullException("RAM was null!");

        var validator = new AddRAMDTOValidator();
        var validationResult = validator.Validate(ram);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }
        var config = _mapper.Map<RAM>(ram);
        _unitOfWork.RAM.Add(config);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteRAMAsync(int id)
    {
        var ramcha = GetRAMByIdAsync(id).Result;
        if (ramcha == null) throw new NotFoundException("RAM not found!");


        var images = ramcha.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
        }
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

        PagedList<RAMDTO> pagedList = new(dtos, dtos.Count(),
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
        if (config == null) throw new NotFoundException("RAM Not Found!");
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
        var ramcha = await _unitOfWork.Housing.GetByIdAsync(ram.ID);
        if (ramcha == null) throw new NotFoundException("RAM not found!");


        var validator = new UpdateRAMDTOValidator();
        var validationResult = validator.Validate(ram);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = ramcha.ImageUrls.Except(ram.ImageUrls);

        foreach (var imageUrl in forDelete)
        {
            await _s3Interface.DeleteFileAsync(imageUrl.Split('/')[^1]);
        }
        var config = _mapper.Map<RAM>(ram);
        _unitOfWork.RAM.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
