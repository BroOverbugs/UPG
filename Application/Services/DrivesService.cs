using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using DTOS.DrivesDTOs;
using Infastructure.Interfaces;

namespace Application.Services;

public class DrivesService(IUnitOfWork unitOfWork,
                           IMapper mapper) : IDrivesService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddDrivesAsync(AddDrivesDTO drivesDTO)
    {
        var model = _mapper.Map<Drives>(drivesDTO);
        _unitOfWork.Drives.Add(model);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteDrivesAsync(int id)
    {
        var data = await _unitOfWork.Drives.GetByIdAsync(id);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {id}  {nameof(id)}");
        }
        _unitOfWork.Drives.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<DrivesDTO>> GetDrivesAllAsync()
    {
        var models = await _unitOfWork.Drives.GetAllAsync();
        return _mapper.Map<IEnumerable<DrivesDTO>>(models);
    }

    public async Task<DrivesDTO> GetDrivesByIdAsync(int id)
    {
        var model = await _unitOfWork.Drives.GetByIdAsync(id);
        if (model == null)
        {
            throw new ArgumentNullException($"Id not found: {id}  {nameof(id)}");
        }
        return _mapper.Map<DrivesDTO>(model);
    }

    public async Task UpdateDrivesAsync(UpdateDrivesDTO drivesDTO)
    {
        var data = await _unitOfWork.Armchairs.GetByIdAsync(drivesDTO.ID);
        if (data == null)
        {
            throw new ArgumentNullException($"Id not found: {drivesDTO.ID}  {nameof(drivesDTO.ID)}");
        }
        var model = _mapper.Map<Drives>(drivesDTO);
        _unitOfWork.Drives.Update(model);
        await _unitOfWork.SaveAsync();
    }
}
