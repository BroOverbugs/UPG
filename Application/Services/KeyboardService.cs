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

namespace Application.Services;

public class KeyboardService(IUnitOfWork unitOfWork,
                             IDistributedCache distributed) : IKeyboardService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<Keyboard> _cache = new RedisService<Keyboard>(distributed);
    private const string CACHE_KEY = "keyboard";

    public async void Create(AddKeyboardDto keyboardDto)
    {
        if (keyboardDto == null) throw new ArgumentNullException("Keyboard was null!");

        var validator = new AddKeyboardDtoValidator();
        var validationResult = validator.Validate(keyboardDto);

        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Keyboard.Add((Keyboard)keyboardDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async void Delete(int id)
    {
        var keyboard = GetByIdAsync(id).Result;
        if (keyboard == null) throw new NotFoundException("Keyboard not found!");

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

    public async void Update(UpdateKeyboardDto keyboardDto)
    {
        var keyboard = GetByIdAsync(keyboardDto.Id).Result;
        if (keyboard == null) throw new NotFoundException("Keyboard not found!");


        var validator = new UpdateKeyboardDtoValidator();
        var validationResult = validator.Validate(keyboardDto);

        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Keyboard.Update((Keyboard)keyboardDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}