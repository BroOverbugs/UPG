using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.GamingBuildsDTOs;
using Infastructure.Interfaces;

namespace Application.Services;

public class GamingBuildsService(IUnitOfWork unitOfWork,
                                 IMapper mapper) : IGamingBuildsService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddGamingBuildsAsync(AddGamingBuildsDTO dto)
    {
        var model = _mapper.Map<GamingBuilds>(dto);
        _unitOfWork.GamingBuilds.Add(model);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteGamingBuildsAsync(int id)
    {
        var data = await _unitOfWork.GamingBuilds.GetByIdAsync(id);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {id}\t{nameof(data)}");
        }
        _unitOfWork.GamingBuilds.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<GamingBuildsDTO>> GetGamingBuildsAsync()
    {
        var models = await _unitOfWork.GamingBuilds.GetAllAsync();
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
        var data = await _unitOfWork.GamingBuilds.GetByIdAsync(dto.ID);
        if (data == null)
        {
            throw new ArgumentNullException($"Model not found: {dto.ID}");
        }
        var model = _mapper.Map<GamingBuilds>(dto);
        _unitOfWork.GamingBuilds.Update(model);
    }
}
