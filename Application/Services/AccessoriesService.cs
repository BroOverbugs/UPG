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

        public Task AddAccessoriesAsync(AddAccessoriesDto addAccessoriesDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccessoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccessoriesDto>> GetAccessoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccessoriesDto> GetAccessoriesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccessoriesAsync(UpdateAccessoriesDto updateAccessoriesDto)
        {
            throw new NotImplementedException();
        }
    }
}
