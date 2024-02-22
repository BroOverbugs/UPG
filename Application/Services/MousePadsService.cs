using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.Mouse_pads;
using DTOS.Power_supplies;
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
    public MousePadsService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
     public async Task AddMousePadsAsync(AddMouse_padsDTO mousepads)
    {
        var config = _mapper.Map<Mouse_pads>(mousepads);
        _unitOfWork.Mouse_pads.Add(config);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteMousePadsAsync(int id)
    {
        _unitOfWork.Mouse_pads.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<PagedList<Mouse_padsDTO>> Filter(FilterParameters parametrs)
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

        var dtos = list.Select(book => _mapper.Map<Mouse_padsDTO>(book)).ToList();

        // Order by title
        if (parametrs.orderByTitle)
        {
            dtos = dtos.OrderBy(book => book.Name).ToList();
        }
        else
        {
            dtos = dtos.OrderByDescending(book => book.Name).ToList();
        }

        PagedList<Mouse_padsDTO> pagedList = new(dtos, dtos.Count,
                                                          parametrs.PageNumber, parametrs.pageSize);

        return pagedList.ToPagedList(dtos, parametrs.PageSize, parametrs.PageNumber);
    }

    public async Task<Mouse_padsDTO> GetMousePadByIdAsync(int id)
    {
        var config = await _unitOfWork.Mouse_pads.GetByIdAsync(id);
        return _mapper.Map<Mouse_padsDTO>(config);
    }

    public async Task<IEnumerable<Mouse_padsDTO>> GetMousePadsAsync()
    {
        var config = await _unitOfWork.Mouse_pads.GetAllAsync();
        var glaive = _mapper.Map<IEnumerable<Mouse_padsDTO>>(config);
        return glaive;
    }

    public async Task<PagedList<Mouse_padsDTO>> GetPagetMousePads(int pageSize, int pageNumber)
    {
        var dtos = await GetMousePadsAsync();
        PagedList<Mouse_padsDTO> pagedList = new(dtos,
                                                          dtos.Count(),
                                                          pageNumber,
                                                          pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task UpdateMousePadsAsync(UpdateMouse_padsDTO mousepads)
    {
        var config = _mapper.Map<Mouse_pads>(mousepads);
        _unitOfWork.Mouse_pads.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
