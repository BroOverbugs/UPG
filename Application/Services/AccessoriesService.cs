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

        public async Task UpdateAccessoriesAsync(UpdateAccessoriesDto updateAccessoriesDto)
        {
            var config = _mapper.Map<Accessories>(updateAccessoriesDto);
            _unitOfWork.Accessories.Update(config);
            await _unitOfWork.SaveAsync();
        }
    }
}
