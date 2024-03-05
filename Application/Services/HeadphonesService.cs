using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Common.Validators.NuraliModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.HeadphonesDTOs;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using DTOS.ArmchairsDTOs;
using UPG.Core.Filters;

namespace Application.Services;

public class HeadphonesService(IUnitOfWork unitOfWork,
                               IMapper mapper,
                               IDistributedCache distributed,
                               IS3Interface s3Interface) : IHeadphonesService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<Headphones> _cache = new RedisService<Headphones>(distributed);
    private readonly IS3Interface _s3Interface = s3Interface;
    private const string CACHE_KEY = "headphones";

    public async Task AddHeadphonesAsync(AddHeadphonesDTO dto)
    {
        if (dto == null) throw new ArgumentNullException("Armchair is required! DTO was null");

        var validateResult = new AddHeadphonesDTOValidator().Validate(dto);

        if (validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors.ToList() };
        }

        var model = _mapper.Map<Headphones>(dto);
        _unitOfWork.Headphones.Add(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task DeleteHeadphonesAsync(int Id)
    {
        var data = await _unitOfWork.Headphones.GetByIdAsync(Id);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {Id}\t{nameof(data)}");
        }

        var images = data.ImageUrls.ToList();
        if (images != null)
            foreach (var image in images)
            {
                await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
            }

        _unitOfWork.Headphones.Delete(Id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<IEnumerable<HeadphonesDTO>> GetHeadphonesAsync()
    {
        var models = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (models == null)
        {
            models = await _unitOfWork.Headphones.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(models, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return _mapper.Map<IEnumerable<HeadphonesDTO>>(models);
    }

    public async Task<HeadphonesDTO> GetHeadphonesByIdAsync(int Id)
    {
        var model = await _unitOfWork.Headphones.GetByIdAsync(Id);
        
        if (model == null)
        {
            throw new ArgumentNullException($"Id not found: {Id}\t{nameof(model)}");
        }

        return _mapper.Map<HeadphonesDTO>(model);
    }

    public async Task UpdateHeadphonesAsync(UpdateHeadphonesDTO dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException($"Model Is Null: {nameof(dto)}");
        }

        var data = await _unitOfWork.Headphones.GetByIdAsync(dto.ID);
        
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {dto.ID}\t{nameof(data)}");
        }

        var validateResult = new UpdateHeadphonesDTOValidator().Validate(dto);

        if (validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors };
        }

        var imageUrls = data.ImageUrls.Except(dto.ImageUrls).ToList();
        if (imageUrls != null)
            foreach (var imageUrl in imageUrls)
            {
                await _s3Interface.DeleteFileAsync(imageUrl.Split("/")[^1]);
            }

        var model = _mapper.Map<Headphones>(dto);
        _unitOfWork.Headphones.Update(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<List<HeadphonesDTO>> Filter(HeadphonesFilter filter)
    {
        var models = await _unitOfWork.Headphones.GetFilteredHeadphonesAsync(filter);
        return _mapper.Map<List<HeadphonesDTO>>(models);  
    }
}
