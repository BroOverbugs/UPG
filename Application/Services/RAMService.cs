using Application.Common.Exceptions;
using Application.Common.Validators.ElyorbekModels.RAMValidators;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.MonitorDTOs;
using DTOS.RAM;
using Infastructure.Interfaces;
using UPG.Core.Filters;

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

    public async Task<List<RAMDTO>> Filter(RAMFilter ramfilter)
    {
        var monitors = await _unitOfWork.RAM.GetFilteredRAM(ramfilter);

        return monitors.Select(i => (RAMDTO)i).ToList();
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

    public async Task UpdateRAMAsync(UpdateRAMDTO ram)
    {
        var power = await _unitOfWork.RAM.GetByIdAsync(ram.ID);
        if (power == null) throw new NotFoundException("RAM not found!");


        var validator = new UpdateRAMDTOValidator();
        var validationResult = validator.Validate(ram);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = power.ImageUrls.Except(ram.ImageUrls);

        foreach (var url in forDelete)
        {
            await _s3Interface.DeleteFileAsync(url.Split('/')[^1]);
        }
        var config = _mapper.Map<RAM>(ram);
        _unitOfWork.RAM.Update(config);
        await _unitOfWork.SaveAsync();
    }
}
