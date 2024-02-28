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

namespace Application.Services;

public class HousingService(IUnitOfWork unitOfWork,
                            IDistributedCache distributed) : IHousingService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<Housing> _cache = new RedisService<Housing>(distributed);
    private const string CACHE_KEY = "housing";

    public async void Create(AddHousingDto housingDto)
    {
        if (housingDto == null) throw new ArgumentNullException("Housing was null!");

        var validator = new AddHousingDtoValidator();
        var validationResult = validator.Validate(housingDto);
        
        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Housing.Add((Housing)housingDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async void Delete(int id)
    {
        var housing = GetByIdAsync(id).Result;
        if (housing == null) throw new NotFoundException("Housing not found!");

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

    public async void Update(UpdateHousingDto housingDto)
    {
        var housing = GetByIdAsync(housingDto.Id).Result;
        if (housing == null) throw new NotFoundException("Housing not found!");


        var validator = new UpdateHousingDtoValidator();
        var validationResult = validator.Validate(housingDto);

        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Housing.Update((Housing)housingDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}
