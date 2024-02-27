using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.CoolerDTOs;
using Infastructure.Interfaces;

namespace Application.Services;

public class CoolerService(IUnitOfWork unitOfWork,
                           IMapper mapper) : ICoolerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddCoolerAsync(AddCoolerDTO coolerDTO)
    {
        if (coolerDTO == null)
        {
            throw new ArgumentNullException($"Model Is Null: {nameof(coolerDTO)}");
        }
        var model = _mapper.Map<Cooler>(coolerDTO);
        _unitOfWork.Cooler.Add(model);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteCoolerAsync(int Id)
    {
        var model = await _unitOfWork.Cooler.GetByIdAsync(Id);
        if (model == null)
        {
            throw new ArgumentNullException($"Id not found: {Id}  {nameof(model)}");
        }
        _unitOfWork.Cooler.Delete(Id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<CoolerDTO> GetCoolerByIdAsync(int Id)
        => _mapper.Map<CoolerDTO>(await _unitOfWork.Cooler.GetByIdAsync(Id));

    public async Task<IEnumerable<CoolerDTO>> GetCoolersAsync()
    {
        var models = await _unitOfWork.Cooler.GetAllAsync();
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
        var model = _mapper.Map<Cooler>(coolerDTO);
        _unitOfWork.Cooler.Update(model);
        await _unitOfWork.SaveAsync();
    }
}
