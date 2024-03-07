using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Common.Validators.NuraliModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.DrivesDTOs;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using DTOS.ArmchairsDTOs;
using FluentValidation;
using UPG.Core.Filters;

namespace Application.Services;

public class DrivesService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IDistributedCache distributed,
                           IS3Interface s3Interface) : IDrivesService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<Drives> _cache = new RedisService<Drives>(distributed);
    private readonly IS3Interface _s3Interface = s3Interface;
    private const string CACHE_KEY = "drives";

    public async Task AddDrivesAsync(AddDrivesDTO drivesDTO)
    {
        if (drivesDTO == null) throw new ArgumentNullException("Drives is required! DTO was null");

        var validateResult = new AddDrivesDTOValidator().Validate(drivesDTO);

        if (!validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors.ToList() };
        }

        var model = _mapper.Map<Drives>(drivesDTO);
        _unitOfWork.Drives.Add(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task DeleteDrivesAsync(int id)
    {
        var data = await _unitOfWork.Drives.GetByIdAsync(id);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {id}  {nameof(id)}");
        }

        var images = data.ImageUrls.ToList();
        if (images != null)
            foreach (var image in images)
            {
                await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
            }

        _unitOfWork.Drives.Delete(id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<IEnumerable<DrivesDTO>> GetDrivesAllAsync()
    {
        var models = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (models == null)
        {
            models = await _unitOfWork.Drives.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(models, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return _mapper.Map<IEnumerable<DrivesDTO>>(models);
    }

    public async Task<DrivesDTO> GetDrivesByIdAsync(int id)
    {
        var model = await _unitOfWork.Drives.GetByIdAsync(id);
        if (model == null)
        {
            throw new ArgumentNullException($"Id not found: {id}  {nameof(id)}");
        }
        return _mapper.Map<DrivesDTO>(model);
    }

    public async Task UpdateDrivesAsync(UpdateDrivesDTO drivesDTO)
    {
        if (drivesDTO == null)
        {
            throw new ArgumentNullException($"Model Is Null: {nameof(drivesDTO)}");
        }

        var data = await _unitOfWork.Armchairs.GetByIdAsync(drivesDTO.ID);
        
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {drivesDTO.ID}  {nameof(drivesDTO.ID)}");
        }

        var validateResult = new UpdateDrivesDTOValidator().Validate(drivesDTO);

        if (!validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors.ToList() };
        }

        var imageUrls = data.ImageUrls.Except(drivesDTO.ImageUrls).ToList();
        if (imageUrls != null)
            foreach (var imageUrl in imageUrls)
            {
                await _s3Interface.DeleteFileAsync(imageUrl.Split("/")[^1]);
            }

        var model = _mapper.Map<Drives>(drivesDTO);
        _unitOfWork.Drives.Update(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<DrivesDTO>> Filter(DrivesFilter filter)
    {
        var models = await _unitOfWork.Drives.GetFilteredDrivesAsync(filter);
        return _mapper.Map<List<DrivesDTO>>(models);
    }
}
