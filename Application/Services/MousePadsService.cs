using Application.Common.Exceptions;
using Application.Common.Validators.ElyorbekModels.MousePadsValidators;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.MonitorDTOs;
using DTOS.Mouse_pads;
using Infastructure.Interfaces;
using UPG.Core.Filters;

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

    public async Task<List<MousePadsDTO>> Filter(MousePadsFilter mousepadsfilter)
    {
        var monitors = await _unitOfWork.Mouse_pads.GetFilteredMousePads(mousepadsfilter);

        return monitors.Select(i => (MousePadsDTO)i).ToList();
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

    public async Task UpdateMousePadsAsync(UpdateMousePadsDTO mousepads)
    {
        var mouse = await _unitOfWork.Mouse_pads.GetByIdAsync(mousepads.ID);
        if (mouse == null) throw new NotFoundException("Mouse Pad not found!");


        var validator = new UpdateMousePadsDtoValidator();
        var validationResult = validator.Validate(mousepads);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = mouse.ImageUrls.Except(mousepads.ImageUrls);

        foreach (var url in forDelete)
        {
            await _s3Interface.DeleteFileAsync(url.Split('/')[^1]);
        }


        var config = _mapper.Map<MousePads>(mousepads);
        _unitOfWork.Mouse_pads.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
