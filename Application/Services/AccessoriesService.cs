using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Common.Validators.AccessoriesValidators;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.AccessoriesDtos;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPG.Core.Filters;

namespace Application.Services;

public class AccessoriesService : IAccessoriesService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IS3Interface _s3Interface;
    private readonly IDistributedCache _distributed;
    private const string CACHE_KEY = "accessory";
    private readonly IRedisService<Accessories> _cache;

    public AccessoriesService(IMapper mapper, IUnitOfWork unitOfWork, IS3Interface s3Interface, IDistributedCache distributed)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _s3Interface = s3Interface;
        _distributed = distributed;
        _cache = new RedisService<Accessories>(distributed);
}

public async Task AddAccessoriesAsync(AddAccessoriesDto addAccessoriesDto)
    {
        if (addAccessoriesDto == null) throw new ArgumentException("Accessoru was null!");

        var validator = new AccessoriesValidator();
        var validatorResult = validator.Validate(addAccessoriesDto);

        if (!validatorResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validatorResult.Errors.ToList() };
        }
        var config = _mapper.Map<Accessories>(addAccessoriesDto);
        _unitOfWork.Accessories.Add(config);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }

    public async Task DeleteAccessoriesAsync(int id)
    {
        var accessory = await _unitOfWork.Accessories.GetByIdAsync(id);
        if (accessory == null) throw new NotFoundException("Accessory not found!");

        var images = accessory.ImageUrls.ToList();
        foreach (var image in images)
        {
            await _s3Interface.DeleteFileAsync(image.Split('/')[^1]);
        }
        _unitOfWork.Accessories.Delete(id);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    
    }

    public async Task<PagedList<AccessoriesDto>> Filter(FilterParameters parameters)
    {
        var list = await _unitOfWork.Accessories.GetAllAsync();

        // Filter by title
        if(parameters.title is not "")
        {
            list = list.Where(book => book.Name.ToLower()
                       .Contains(parameters.Title.ToLower()));
        }

        // Filter by Price
        list = list.Where(book => book.Price >= parameters.minPrice &&
                                      book.Price <= parameters.maxPrice);   
        
        var dtos = list.Select(book => _mapper.Map<AccessoriesDto>(book)).ToList();

        // Order by title
        if (parameters.orderByTitle)
        {
            dtos = dtos.OrderBy(book => book.Name).ToList();
        }
        else
        {
            dtos = dtos.OrderByDescending(book => book.Name).ToList();
        }

        PagedList<AccessoriesDto> pagedList = new(dtos, dtos.Count,
                                                            parameters.PageNumber, parameters.pageSize);

        return pagedList.ToPagedList(dtos, parameters.PageSize, parameters.PageNumber);
    }

    public async Task<List<AccessoriesDto>> FilterAsync(AccessoriesFilter accessoriesFilter)
    {
        var accessories = await _unitOfWork.Accessories.GetFilteredAccessoriesAsync(accessoriesFilter);
        return accessories.Select(i => _mapper.Map<AccessoriesDto>(i)).ToList();
    }

    public async Task<IEnumerable<AccessoriesDto>> GetAccessoriesAsync()
    {
        var accessories = await _cache.GetFromCacheAsync(CACHE_KEY);
        if (accessories == null)
        {
            accessories = await _unitOfWork.Accessories.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(accessories, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        return accessories.Select(accessory => _mapper.Map<AccessoriesDto>(accessory));
    }

    public async Task<AccessoriesDto> GetAccessoriesByIdAsync(int id)
    {
        var accessories = await _cache.GetFromCacheAsync(CACHE_KEY);
        if(accessories == null)
        {
            accessories = await _unitOfWork.Accessories.GetAllAsync();
            await _cache.SaveToCacheAsync(JsonConvert.SerializeObject(accessories, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), CACHE_KEY);
        }
        var accessory = accessories.FirstOrDefault(i => i.Id == id);
        if (accessory == null) throw new NotFoundException("Accessory not found!");
        return _mapper.Map<AccessoriesDto>(accessory);
    }

    public async Task<PagedList<AccessoriesDto>> GetPagetAccessories(int pageSize, int pageNumber)
    {
        var dtos = await GetAccessoriesAsync();
        PagedList<AccessoriesDto> pagedList = new(dtos,
                                                       dtos.Count(),
                                                       pageNumber,
                                                       pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task UpdateAccessoriesAsync(UpdateAccessoriesDto updateAccessoriesDto)
    {
        var accessory = await _unitOfWork.Accessories.GetByIdAsync(updateAccessoriesDto.ID);
        if (accessory == null) throw new NotFoundException("Accessory not found");


        var validator = new UpdateAccessoriesDtoValidator();
        var validatorResult = validator.Validate(updateAccessoriesDto);

        if (!validatorResult.IsValid)
        {
            throw new ResponseErrors() { Errors = validatorResult.Errors.ToList() };
        }

        var forDelete = accessory.ImageUrls.Except(updateAccessoriesDto.ImageUrls);

        foreach (var imageUrl in forDelete)
        {
            await _s3Interface.DeleteFileAsync(imageUrl.Split('/')[^1]);
        }
        var upaccessuary = _mapper.Map<Accessories>(updateAccessoriesDto);
        _unitOfWork.Accessories.Update(upaccessuary);
        await _unitOfWork.SaveAsync();
        _distributed.Remove(CACHE_KEY);
    }
}
