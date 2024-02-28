using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Common.Validators.HousingValidators;
using Application.Interfaces;
using Domain.Entities;
using DTOS.HousingDTOs;
using FluentValidation.Results;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading;

namespace Application.Services;

public class HousingService(IUnitOfWork unitOfWork,
                            IDistributedCache distributed,
                            IS3Interface s3Interface) : IHousingService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IS3Interface _s3Interface = s3Interface;
    private readonly IRedisService<Housing> _cache = new RedisService<Housing>(distributed);
    private const string CACHE_KEY = "housing";

    public async Task Create(AddHousingDto housingDto)
    {
        if (housingDto == null) throw new ArgumentNullException("Housing was null!");

        var validator = new AddHousingDtoValidator();
        var validationResult = validator.Validate(housingDto);
        
        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        _unitOfWork.Housing.Add((Housing)housingDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task Delete(int id)
    {
        var housing = GetByIdAsync(id).Result;
        if (housing == null) throw new NotFoundException("Housing not found!");


        var images = housing.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
        }

        _unitOfWork.Housing.Delete(id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<HousingDto>> GetAllAsync()
    {
        var housings = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (housings == null)
        {
            housings = await _unitOfWork.Housing.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(housings, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return housings.Select(i => (HousingDto)i).ToList();
    }

    public async Task<HousingDto> GetByIdAsync(int id)
    {
        var housings = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (housings == null)
        {
            housings = await _unitOfWork.Housing.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(housings, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        var housing =  housings.FirstOrDefault(i => i.Id == id);
        if (housing == null) throw new NotFoundException("Housing Not Found!");
        return housing;
    }

    public async Task Update(UpdateHousingDto housingDto)
    {
        var housing = await _unitOfWork.Housing.GetByIdAsync(housingDto.Id);
        if (housing == null) throw new NotFoundException("Housing not found!");


        var validator = new UpdateHousingDtoValidator();
        var validationResult = validator.Validate(housingDto);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = housing.ImageUrls.Except(housingDto.ImageUrls);

        foreach (var imageUrl in forDelete)
        {
            await _s3Interface.DeleteFileAsync(imageUrl.Split('/')[^1]);
        }

        _unitOfWork.Housing.Update((Housing)housingDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}
