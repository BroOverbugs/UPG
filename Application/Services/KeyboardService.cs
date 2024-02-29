using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Interfaces;
using Domain.Entities;
using DTOS.KeyboardDTOs;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Application.Common.Validators.KeyboardValidators;
using FluentValidation.Results;
using UPG.Core.Filters;

namespace Application.Services;

public class KeyboardService(IUnitOfWork unitOfWork,
                             IDistributedCache distributed,
                             IS3Interface s3Interface) : IKeyboardService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IS3Interface _s3Interface = s3Interface;
    private readonly IRedisService<Keyboard> _cache = new RedisService<Keyboard>(distributed);
    private const string CACHE_KEY = "keyboard";

    public async Task Create(AddKeyboardDto keyboardDto)
    {
        if (keyboardDto == null) throw new ArgumentNullException("Keyboard was null!");

        var validator = new AddKeyboardDtoValidator();
        var validationResult = validator.Validate(keyboardDto);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        _unitOfWork.Keyboard.Add((Keyboard)keyboardDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task Delete(int id)
    {
        var keyboard = GetByIdAsync(id).Result;
        if (keyboard == null) throw new NotFoundException("Keyboard not found!");

        var images = keyboard.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
        }

        _unitOfWork.Keyboard.Delete(id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<KeyboardDto>> GetAllAsync()
    {
        var keyboards = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (keyboards == null)
        {
            keyboards = await _unitOfWork.Keyboard.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(keyboards, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return keyboards.Select(i => (KeyboardDto)i).ToList();
    }

    public async Task<KeyboardDto> GetByIdAsync(int id)
    {
        var keyboards = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (keyboards == null)
        {
            keyboards = await _unitOfWork.Keyboard.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(keyboards, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        var keyboard = keyboards.FirstOrDefault(i => i.Id == id);
        if (keyboard == null) throw new NotFoundException("Keyboard Not Found!");
        return keyboard;
    }

    public async Task Update(UpdateKeyboardDto keyboardDto)
    {
        var keyboard = GetByIdAsync(keyboardDto.Id).Result;
        if (keyboard == null) throw new NotFoundException("Keyboard not found!");


        var validator = new UpdateKeyboardDtoValidator();
        var validationResult = validator.Validate(keyboardDto);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = keyboard.ImageUrls.Except(keyboardDto.ImageUrls).ToList();

        foreach (var imageUrl in forDelete)
        {
            await _s3Interface.DeleteFileAsync(imageUrl.Split('/')[^1]);
        }

        _unitOfWork.Keyboard.Update((Keyboard)keyboardDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<KeyboardDto>> FilterAsync(KeyboardFilter keyboardFilter)
    {
        var keyboards = await _unitOfWork.Keyboard.GetFilteredKeyboard(keyboardFilter);

        return keyboards.Select(i => (KeyboardDto)i).ToList();
    }
}