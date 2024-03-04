using Application.Common.Exceptions;
using Application.Common.Validators.ElyorbekModels.PowerSuppliesValidators;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.MonitorDTOs;
using DTOS.Power_supplies;
using Infastructure.Interfaces;
using UPG.Core.Filters;

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

    public async Task<List<PowerSuppliesDTO>> Filter(PowerSuppliesFIlter powerSuppliesfilter)
    {
        var power = await _unitOfWork.Power_supplies.GetFilteredPowerSupplies(powerSuppliesfilter);

        return power.Select(i => (PowerSuppliesDTO)i).ToList();
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
