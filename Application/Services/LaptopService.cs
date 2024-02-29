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
using UPG.Core.Filters;

namespace Application.Services;

public class LaptopService(IUnitOfWork unitOfWork,
                           IDistributedCache distributed,
                           IS3Interface s3Interface) : ILaptopService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IS3Interface _s3Interface = s3Interface;
    private readonly IRedisService<Laptop> _cache = new RedisService<Laptop>(distributed);
    private const string CACHE_KEY = "laptop";

    public async Task Create(AddLaptopDto laptopDto)
    {
        if (laptopDto == null) throw new ArgumentNullException("Laptop was null!");

        var validator = new AddLaptopDtoValidator();
        var validationResult = validator.Validate(laptopDto);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        _unitOfWork.Laptop.Add((Laptop)laptopDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task Delete(int id)
    {
        var laptop = GetByIdAsync(id).Result;
        if (laptop == null) throw new NotFoundException("Laptop not found!");

        var images = laptop.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
        }

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

    public async Task Update(UpdateLaptopDto laptopDto)
    {
        var laptop = GetByIdAsync(laptopDto.Id).Result;
        if (laptop == null) throw new NotFoundException("Laptop not found!");


        var validator = new UpdateLaptopDtoValidator();
        var validationResult = validator.Validate(laptopDto);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = laptop.ImageUrls.Except(laptopDto.ImageUrls).ToList();

        foreach (var imageUrl in forDelete)
        {
            await _s3Interface.DeleteFileAsync(imageUrl.Split('/')[^1]);
        }

        _unitOfWork.Laptop.Update((Laptop)laptopDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<LaptopDto>> FilterAsync(LaptopFilter laptopFilter)
    {
        var laptops = await _unitOfWork.Laptop.GetFilteredLaptop(laptopFilter);

        return laptops.Select(i => (LaptopDto)i).ToList();
    }
}