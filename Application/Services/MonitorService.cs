using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Interfaces;
using DTOS.MonitorDTOs;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Application.Common.Validators.MonitorValidators;
using FluentValidation.Results;

namespace Application.Services;

public class MonitorService(IUnitOfWork unitOfWork,
                           IDistributedCache distributed) : IMonitorService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<Domain.Entities.Monitor> _cache = new RedisService<Domain.Entities.Monitor>(distributed);
    private const string CACHE_KEY = "monitor";

    public async void Create(AddMonitorDto monitorDto)
    {
        if (monitorDto == null) throw new ArgumentNullException("Monitor was null!");

        var validator = new AddMonitorDtoValidator();
        var validationResult = validator.Validate(monitorDto);

        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Monitor.Add((Domain.Entities.Monitor)monitorDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async void Delete(int id)
    {
        var monitor = GetByIdAsync(id).Result;
        if (monitor == null) throw new NotFoundException("Monitor not found!");

        _unitOfWork.Monitor.Delete(id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<MonitorDto>> GetAllAsync()
    {
        var monitors = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (monitors == null)
        {
            monitors = await _unitOfWork.Monitor.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(monitors, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return monitors.Select(i => (MonitorDto)i).ToList();
    }

    public async Task<MonitorDto> GetByIdAsync(int id)
    {
        var monitors = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (monitors == null)
        {
            monitors = await _unitOfWork.Monitor.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(monitors, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        var monitor = monitors.FirstOrDefault(i => i.Id == id);
        if (monitor == null) throw new NotFoundException("Monitor Not Found!");
        return monitor;
    }

    public async void Update(UpdateMonitorDto monitorDto)
    {
        var monitor = GetByIdAsync(monitorDto.Id).Result;
        if (monitor == null) throw new NotFoundException("Monitor not found!");


        var validator = new UpdateMonitorDtoValidator();
        var validationResult = validator.Validate(monitorDto);

        if (!validationResult.IsValid)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            foreach (var error in validationResult.Errors)
            {
                failures.Add(error);
            }
            throw new ResponseErrors() { Errors = failures };
        }

        _unitOfWork.Monitor.Update((Domain.Entities.Monitor)monitorDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}