using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Interfaces;
using Domain.Entities;
using DTOS.LaptopDTOs;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Application.Common.Validators.LaptopValidators;
using FluentValidation.Results;

namespace Application.Services;

public class LaptopService(IUnitOfWork unitOfWork,
                           IDistributedCache distributed) : ILaptopService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<Laptop> _cache = new RedisService<Laptop>(distributed);
    private const string CACHE_KEY = "laptop";

    public async void Create(AddLaptopDto laptopDto)
    {
        if (laptopDto == null) throw new ArgumentNullException("Laptop was null!");

        var validator = new AddLaptopDtoValidator();
        var validationResult = validator.Validate(laptopDto);

        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Laptop.Add((Laptop)laptopDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async void Delete(int id)
    {
        var laptop = GetByIdAsync(id).Result;
        if (laptop == null) throw new NotFoundException("Laptop not found!");

        _unitOfWork.Laptop.Delete(id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<LaptopDto>> GetAllAsync()
    {
        var laptops = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (laptops == null)
        {
            laptops = await _unitOfWork.Laptop.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(laptops, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return laptops.Select(i => (LaptopDto)i).ToList();
    }

    public async Task<LaptopDto> GetByIdAsync(int id)
    {
        var laptops = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (laptops == null)
        {
            laptops = await _unitOfWork.Laptop.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(laptops, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        var laptop = laptops.FirstOrDefault(i => i.Id == id);
        if (laptop == null) throw new NotFoundException("Laptop Not Found!");
        return laptop;
    }

    public async void Update(UpdateLaptopDto laptopDto)
    {
        var laptop = GetByIdAsync(laptopDto.Id).Result;
        if (laptop == null) throw new NotFoundException("Laptop not found!");


        var validator = new UpdateLaptopDtoValidator();
        var validationResult = validator.Validate(laptopDto);

        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Laptop.Update((Laptop)laptopDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}