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

namespace Application.Services;

public class MonitorService(IUnitOfWork unitOfWork,
                           IDistributedCache distributed,
                           IS3Interface s3Interface) : IMonitorService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IS3Interface _s3Interface = s3Interface;
    private readonly IRedisService<Domain.Entities.Monitor> _cache = new RedisService<Domain.Entities.Monitor>(distributed);
    private const string CACHE_KEY = "monitor";

    public async Task Create(AddMonitorDto monitorDto)
    {
        if (monitorDto == null) throw new ArgumentNullException("Monitor was null!");

        var validator = new AddMonitorDtoValidator();
        var validationResult = validator.Validate(monitorDto);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList()};
        }

        _unitOfWork.Monitor.Add((Domain.Entities.Monitor)monitorDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task Delete(int id)
    {
        var monitor = await _unitOfWork.Monitor.GetByIdAsync(id);
        if (monitor == null) throw new NotFoundException("Monitor not found!");

        var images = monitor.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
        }
        _unitOfWork.Monitor.Delete(id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<MonitorDto>> GetAllAsync()
    {
        var monitors = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (monitors == null || monitors.Count() == 0)
        {
            monitors = await _unitOfWork.Monitor.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(monitors, Formatting.None, new JsonSerializerSettings
            {   
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), CACHE_KEY); 
        }
        var test = monitors.Select(i => (MonitorDto)i).ToList();
        return test;
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

    public async Task Update(UpdateMonitorDto monitorDto)
    {
        var monitor = await _unitOfWork.Monitor.GetByIdAsync(monitorDto.Id);
        if (monitor == null) throw new NotFoundException("Monitor not found!");


        var validator = new UpdateMonitorDtoValidator();
        var validationResult = validator.Validate(monitorDto);

        if (!validationResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validationResult.Errors.ToList() };
        }

        var forDelete = monitor.ImageUrls.Except(monitorDto.ImageUrls);

        foreach (var url in forDelete)
        {
            await _s3Interface.DeleteFileAsync(url.Split('/')[^1]);
        }

        _unitOfWork.Monitor.Update((Domain.Entities.Monitor)monitorDto);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}