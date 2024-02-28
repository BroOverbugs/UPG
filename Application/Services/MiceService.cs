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
using DTOS.KeyboardDTOs;

namespace Application.Services;

public class MiceService(IUnitOfWork unitOfWork,
                           IDistributedCache distributed,
                           IS3Interface s3Interface) : IMiceService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IS3Interface _s3Interface = s3Interface;
    private readonly IRedisService<Mice> _cache = new RedisService<Mice>(distributed);
    private const string CACHE_KEY = "mice";

    public async Task Create(AddMiceDto miceDto)
    {
        if (miceDto == null) throw new ArgumentNullException("Mice was null!");

        var validator = new AddMiceDtoValidator();
        var validationResult = validator.Validate(miceDto);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        _unitOfWork.Mice.Add((Mice)miceDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task Delete(int id)
    {
        var mice = GetByIdAsync(id).Result;
        if (mice == null) throw new NotFoundException("Mice not found!");


        var images = mice.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
        }

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

    public async Task Update(UpdateMiceDto miceDto)
    {
        var mice = GetByIdAsync(miceDto.Id).Result;
        if (mice == null) throw new NotFoundException("Mice not found!");


        var validator = new UpdateMiceDtoValidator();
        var validationResult = validator.Validate(miceDto);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = mice.ImageUrls.Except(miceDto.ImageUrls).ToList();

        foreach (var imageUrl in forDelete)
        {
            await _s3Interface.DeleteFileAsync(imageUrl.Split('/')[^1]);
        }

        _unitOfWork.Mice.Update((Mice)miceDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}