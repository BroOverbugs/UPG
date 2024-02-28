using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Interfaces;
using Domain.Entities;
using DTOS.MiceDTOs;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Application.Common.Validators.MiceValidators;
using FluentValidation.Results;

namespace Application.Services;

public class MiceService(IUnitOfWork unitOfWork,
                           IDistributedCache distributed) : IMiceService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<Mice> _cache = new RedisService<Mice>(distributed);
    private const string CACHE_KEY = "mice";

    public async void Create(AddMiceDto miceDto)
    {
        if (miceDto == null) throw new ArgumentNullException("Mice was null!");

        var validator = new AddMiceDtoValidator();
        var validationResult = validator.Validate(miceDto);

        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Mice.Add((Mice)miceDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async void Delete(int id)
    {
        var mice = GetByIdAsync(id).Result;
        if (mice == null) throw new NotFoundException("Mice not found!");

        _unitOfWork.Mice.Delete(id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<MiceDto>> GetAllAsync()
    {
        var mices = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (mices == null)
        {
            mices = await _unitOfWork.Mice.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(mices, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return mices.Select(i => (MiceDto)i).ToList();
    }

    public async Task<MiceDto> GetByIdAsync(int id)
    {
        var mices = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (mices == null)
        {
            mices = await _unitOfWork.Mice.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(mices, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        var mice = mices.FirstOrDefault(i => i.Id == id);
        if (mice == null) throw new NotFoundException("Mice Not Found!");
        return mice;
    }

    public async void Update(UpdateMiceDto miceDto)
    {
        var mice = GetByIdAsync(miceDto.Id).Result;
        if (mice == null) throw new NotFoundException("Mice not found!");


        var validator = new UpdateMiceDtoValidator();
        var validationResult = validator.Validate(miceDto);

        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Mice.Update((Mice)miceDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}