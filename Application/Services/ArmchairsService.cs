using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Common.Validators.NuraliModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.ArmchairsDTOs;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Application.Services;

public class ArmchairsService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              IDistributedCache distributed,
                              IS3Interface s3Interface) : IArmchairsService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IDistributedCache _distributed = distributed;
    private readonly IRedisService<Armchairs> _cache = new RedisService<Armchairs>(distributed);
    private readonly IS3Interface _s3Interface = s3Interface;
    private const string CACHE_KEY = "armchairs";
    public async Task AddArmchairsAsync(AddArmchairsDTO dto)
    {
        if (dto == null) throw new ArgumentNullException("Armchair is required! DTO was null");

        var validateResult = new AddArmchairsDTOValidator().Validate(dto);

        if (validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors.ToList() };
        }

        var model = _mapper.Map<Armchairs>(dto);
        _unitOfWork.Armchairs.Add(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task DeleteArmchairsAsync(int Id)
    {
        var data = await _unitOfWork.Armchairs.GetByIdAsync(Id);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {Id}  {nameof(Id)}");
        }

        var images = data.ImageUrls.ToList();
        if (images != null)
            foreach (var image in images)
            {
                await _s3Interface.DeleteFileAsync(image.Split("/")[^1]);
            }

        _unitOfWork.Armchairs.Delete(Id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task<IEnumerable<ArmchairsDTO>> GetArmchairsAsync()
    {
        var models = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (models == null)
        {
            models = await _unitOfWork.Armchairs.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(models, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return _mapper.Map<IEnumerable<ArmchairsDTO>>(models);
    }

    public async Task<ArmchairsDTO> GetArmchairsByIdAsync(int Id)
    {
        var model = await _unitOfWork.Armchairs.GetByIdAsync(Id);
        if (model == null)
        {
            throw new ArgumentNullException($"Id not found: {Id}\t{nameof(model)}");
        }
        return _mapper.Map<ArmchairsDTO>(model);
    }

    public async Task UpdateArmchairsAsync(UpdateArmchairsDTO updateArmchairsDTO)
    {
        if (updateArmchairsDTO == null)
        {
            throw new ArgumentNullException($"Model Is Null: {nameof(updateArmchairsDTO)}");
        }
        
        var data = await _unitOfWork.Armchairs.GetByIdAsync(updateArmchairsDTO.ID);
        
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {updateArmchairsDTO.ID}  {nameof(updateArmchairsDTO)}");
        }

        var validateResult = new UpdateArmchairsDTOValidator().Validate(updateArmchairsDTO);
        
        if (validateResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validateResult.Errors.ToList() };
        }

        var imageUrls = data.ImageUrls.Except(updateArmchairsDTO.ImageUrls).ToList();
        if (imageUrls != null)
            foreach (var imageUrl in imageUrls)
            {
                await _s3Interface.DeleteFileAsync(imageUrl.Split("/")[^1]);
            }

        var model = _mapper.Map<Armchairs>(updateArmchairsDTO);
        _unitOfWork.Armchairs.Update(model);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}
