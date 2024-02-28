using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.HeadphonesDTOs;
using Infastructure.Interfaces;

namespace Application.Services;

public class HeadphonesService(IUnitOfWork unitOfWork,
                               IMapper mapper) : IHeadphonesService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddHeadphonesAsync(AddHeadphonesDTO dto)
    {
        var model = _mapper.Map<Headphones>(dto);
        _unitOfWork.Headphones.Add(model);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteHeadphonesAsync(int Id)
    {
        var data = await _unitOfWork.Headphones.GetByIdAsync(Id);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {Id}\t{nameof(data)}");
        }
        _unitOfWork.Headphones.Delete(Id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<HeadphonesDTO>> GetHeadphonesAsync()
    {
        var models = await _unitOfWork.Headphones.GetAllAsync();
        return _mapper.Map<IEnumerable<HeadphonesDTO>>(models);
    }

    public async Task<HeadphonesDTO> GetHeadphonesByIdAsync(int Id)
    {
        var model = await _unitOfWork.Headphones.GetByIdAsync(Id);
        return _mapper.Map<HeadphonesDTO>(model);
    }

    public async Task UpdateHeadphonesAsync(UpdateHeadphonesDTO dto)
    {
        var data = await _unitOfWork.Headphones.GetByIdAsync(dto.ID);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {dto.ID}\t{nameof(data)}");
        }
        var model = _mapper.Map<Headphones>(dto);
        _unitOfWork.Headphones.Update(model);
        await _unitOfWork.SaveAsync();
    }
}
