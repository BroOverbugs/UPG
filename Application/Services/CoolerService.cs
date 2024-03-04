using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Common.Validators.NuraliModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.CoolerDTOs;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services;

public class CoolerService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IDistributedCache distributed,
                           IS3Interface s3Interface) : ICoolerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<Cooler> _cache = new RedisService<Cooler>(distributed);
    private readonly IS3Interface _s3Interface = s3Interface;
    private const string CACHE_KEY = "cooler";

    public async Task AddCoolerAsync(AddCoolerDTO coolerDTO)
    {
        if (coolerDTO == null)
        {
            throw new ArgumentNullException($"Model Is Null: {nameof(coolerDTO)}");
        }

        var validateResult = new AddCoolerDTOValidator().Validate(coolerDTO);

        if (validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors.ToList() };
        }

        var model = _mapper.Map<Cooler>(coolerDTO);
        _unitOfWork.Cooler.Add(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task DeleteCoolerAsync(int Id)
    {
        var model = await _unitOfWork.Cooler.GetByIdAsync(Id);
        if (model == null)
        {
            throw new ArgumentNullException($"Id not found: {Id}  {nameof(model)}");
        }

        var images = model.ImageUrls.ToList();
        if (images != null)
            foreach (var image in images)
            {
                await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
            }


        _unitOfWork.Cooler.Delete(Id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<CoolerDTO> GetCoolerByIdAsync(int Id)
    {
        var model = await _unitOfWork.Cooler.GetByIdAsync(Id);
        if (model == null)
        {
            throw new ArgumentNullException($"Id not found: {Id}\t{nameof(model)}");
        }
        return _mapper.Map<CoolerDTO>(model);
    }

    public async Task<IEnumerable<CoolerDTO>> GetCoolersAsync()
    {
        var models = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (models == null)
        {
            models = await _unitOfWork.Cooler.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(models, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }

        return _mapper.Map<IEnumerable<CoolerDTO>>(models);
    }

    public async Task UpdateCoolerAsync(UpdateCoolerDTO coolerDTO)
    {
        if (coolerDTO == null)
        {
            throw new ArgumentNullException($"Model Is Null: {nameof(coolerDTO)}");
        }

        var data = await _unitOfWork.Cooler.GetByIdAsync(coolerDTO.ID);
        
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {coolerDTO.ID}  {nameof(coolerDTO)}");
        }
        
        var validateResult = new UpdateCoolerDTOValidator().Validate(coolerDTO);

        if (validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors };
        }

        var imageUrls = data.ImageUrls.Except(coolerDTO.ImageUrls).ToList();

        if (imageUrls != null)
            foreach (var imageUrl in imageUrls)
            {
                await _s3Interface.DeleteFileAsync(imageUrl.Split("/")[^1]);
            }

        var model = _mapper.Map<Cooler>(coolerDTO);
        _unitOfWork.Cooler.Update(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}
