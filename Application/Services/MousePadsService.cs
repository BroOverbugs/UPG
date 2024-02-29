using Application.Common.Exceptions;
using Application.Common.Validators.ElyorbekModels.MousePadsValidators;
using Application.Common.Validators.HousingValidators;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.HousingDTOs;
using DTOS.Mouse_pads;
using DTOS.Power_supplies;
using FluentValidation;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class MousePadsService : IMousePadsService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IS3Interface _s3Interface;
    public MousePadsService(IMapper mapper, IUnitOfWork unitOfWork,IS3Interface s3Interface)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _s3Interface = s3Interface;
    }
     public async Task AddMousePadsAsync(AddMousePadsDTO mousepads)
    {
        if (mousepads == null) throw new ArgumentNullException("MousePads was null!");

        var validator = new AddMousePadsDtoValidator();
        var validationResult = validator.Validate(mousepads);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }
        var config = _mapper.Map<MousePads>(mousepads);
        _unitOfWork.Mouse_pads.Add(config);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteMousePadsAsync(int id)
    {
        var mousepads = GetMousePadByIdAsync(id).Result;
        if (mousepads == null) throw new NotFoundException("Mousepad not found!");


        var images = mousepads.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
        }
        _unitOfWork.Mouse_pads.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<PagedList<MousePadsDTO>> Filter(FilterParameters parametrs)
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

        var dtos = list.Select(book => _mapper.Map<MousePadsDTO>(book)).ToList();

        // Order by title
        if (parametrs.orderByTitle)
        {
            dtos = dtos.OrderBy(book => book.Name).ToList();
        }
        else
        {
            dtos = dtos.OrderByDescending(book => book.Name).ToList();
        }

        PagedList<MousePadsDTO> pagedList = new(dtos, dtos.Count(),
                                                          parametrs.PageNumber, parametrs.pageSize);

        return pagedList.ToPagedList(dtos, parametrs.PageSize, parametrs.PageNumber);
    }

    public async Task<MousePadsDTO> GetMousePadByIdAsync(int id)
    {
        var config = await _unitOfWork.Mouse_pads.GetByIdAsync(id);

        if (config == null) throw new NotFoundException("MousePads Not Found!");
        return _mapper.Map<MousePadsDTO>(config);
    }

    public async Task<IEnumerable<MousePadsDTO>> GetMousePadsAsync()
    {
        var config = await _unitOfWork.Mouse_pads.GetAllAsync();
        var glaive = _mapper.Map<IEnumerable<MousePadsDTO>>(config);
        return glaive;
    }

    public async Task<PagedList<MousePadsDTO>> GetPagetMousePads(int pageSize, int pageNumber)
    {
        var dtos = await GetMousePadsAsync();
        PagedList<MousePadsDTO> pagedList = new(dtos,
                                                          dtos.Count(),
                                                          pageNumber,
                                                          pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task UpdateMousePadsAsync(UpdateMousePadsDTO mousepads)
    {
        var Mousepads = await _unitOfWork.Housing.GetByIdAsync(mousepads.ID);
        if (Mousepads == null) throw new NotFoundException("MousePads not found!");


        var validator = new UpdateMousePadsDtoValidator();
        var validationResult = validator.Validate(mousepads);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = Mousepads.ImageUrls.Except(mousepads.ImageUrls);

        foreach (var imageUrl in forDelete)
        {
            await _s3Interface.DeleteFileAsync(imageUrl.Split('/')[^1]);
        }

        var config = _mapper.Map<MousePads>(mousepads);
        _unitOfWork.Mouse_pads.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
