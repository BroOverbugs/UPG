using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.AccessoriesDtos;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPG.Core.Filters;

namespace Application.Services
{
    public class AccessoriesService : IAccessoriesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccessoriesService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAccessoriesAsync(AddAccessoriesDto addAccessoriesDto)
        {
            var config = _mapper.Map<Accessories>(addAccessoriesDto);
            _unitOfWork.Accessories.Add(config);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAccessoriesAsync(int id)
        {
            _unitOfWork.Accessories.Delete(id);
            await _unitOfWork.SaveAsync();
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
            var config = await _unitOfWork.Accessories.GetAllAsync();
            var glaive = _mapper.Map<IEnumerable<AccessoriesDto>>(config);
            return glaive;
        }

        public async Task<AccessoriesDto> GetAccessoriesByIdAsync(int id)
        {
            var config = await _unitOfWork.Accessories.GetByIdAsync(id);
            return _mapper.Map<AccessoriesDto>(config);
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
            var config = _mapper.Map<Accessories>(updateAccessoriesDto);
            _unitOfWork.Accessories.Update(config);
            await _unitOfWork.SaveAsync();
        }
    }
}
