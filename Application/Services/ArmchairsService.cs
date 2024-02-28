using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.ArmchairsDTOs;
using DTOS.CoolerDTOs;
using Infastructure.Interfaces;

namespace Application.Services;

public class ArmchairsService(IUnitOfWork unitOfWork,
                              IMapper mapper) : IArmchairsService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddArmchairsAsync(AddArmchairsDTO dto)
    {
        var model = _mapper.Map<Armchairs>(dto);
        _unitOfWork.Armchairs.Add(model);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteArmchairsAsync(int Id)
    {
        var data = await _unitOfWork.Armchairs.GetByIdAsync(Id);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {Id}  {nameof(Id)}");
        }
        _unitOfWork.Armchairs.Delete(Id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<ArmchairsDTO>> GetArmchairsAsync()
    {
        var models = await _unitOfWork.Armchairs.GetAllAsync();
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
        var model = _mapper.Map<Armchairs>(updateArmchairsDTO);
        _unitOfWork.Armchairs.Update(model);
        await _unitOfWork.SaveAsync();
    }
}
