using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Common.Validators.NuraliModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.GamingBuildsDTOs;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using DTOS.ArmchairsDTOs;

namespace Application.Services;

public class GamingBuildsService(IUnitOfWork unitOfWork,
                                 IMapper mapper,
                                 IDistributedCache distributed,
                                 IS3Interface s3Interface) : IGamingBuildsService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<GamingBuilds> _cache = new RedisService<GamingBuilds>(distributed);
    private readonly IS3Interface _s3Interface = s3Interface;
    private const string CACHE_KEY = "gamingBuilds";

    public async Task AddGamingBuildsAsync(AddGamingBuildsDTO dto)
    {
        if (dto == null) throw new ArgumentNullException("Armchair is required! DTO was null");

        var validateResult = new AddGamingBuildsDTOValidator().Validate(dto);

        if (validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors.ToList() };
        }

        var model = _mapper.Map<GamingBuilds>(dto);
        _unitOfWork.GamingBuilds.Add(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task DeleteGamingBuildsAsync(int id)
    {
        var data = await _unitOfWork.GamingBuilds.GetByIdAsync(id);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {id}\t{nameof(data)}");
        }

        var images = data.ImageUrls.ToList();
        if (images != null)
            foreach (var image in images)
            {
                await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
            }

        _unitOfWork.GamingBuilds.Delete(id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<IEnumerable<GamingBuildsDTO>> GetGamingBuildsAsync()
    {
        var models = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (models == null)
        {
            models = await _unitOfWork.GamingBuilds.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(models, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return _mapper.Map<IEnumerable<GamingBuildsDTO>>(models);
    }

    public async Task<GamingBuildsDTO> GetGamingBuildsByIdAsync(int id)
    {
        var model = await _unitOfWork.GamingBuilds.GetByIdAsync(id);
        if (model == null)
        {
            throw new ArgumentNullException($"Id not found: {id}");
        }
        return _mapper.Map<GamingBuildsDTO>(model);
    }

    public async Task UpdateGamingBuildsAsync(UpdateGamingBuildsDTO dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException($"Model Is Null: {nameof(dto)}");
        }

        var data = await _unitOfWork.GamingBuilds.GetByIdAsync(dto.ID);
       
        if (data == null)
        {
            throw new ArgumentNullException($"Model not found: {dto.ID}");
        }

        var validateResult = new UpdateGamingBuildsDTOValidator().Validate(dto);

        if (validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors.ToList() };
        }

        var imageUrls = data.ImageUrls.Except(dto.ImageUrls).ToList();
        if (imageUrls != null)
            foreach (var imageUrl in imageUrls)
            {
                await _s3Interface.DeleteFileAsync(imageUrl.Split("/")[^1]);
            }

        var model = _mapper.Map<GamingBuilds>(dto);
        _unitOfWork.GamingBuilds.Update(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}
