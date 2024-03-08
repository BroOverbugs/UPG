using AutoMapper;
using Domain.Entities;
using DTOS.AccessoriesDtos;
using DTOS.ArmchairsDTOs;
using DTOS.CoolerDTOs;
using DTOS.DrivesDTOs;
using DTOS.GamingBuildsDTOs;
using DTOS.HeadphonesDTOs;
using DTOS.MousePadDTOs;
using DTOS.Power_supplies;
using DTOS.RAM;
using DTOS.Tables_for_gamers;

namespace Application.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Armchairs, ArmchairsDTO>();
        CreateMap<AddArmchairsDTO, Armchairs>();
        CreateMap<UpdateArmchairsDTO, Armchairs>();

        CreateMap<Cooler, CoolerDTO>();
        CreateMap<AddCoolerDTO, Cooler>();
        CreateMap<UpdateCoolerDTO, Cooler>();

        CreateMap<Drives, DrivesDTO>();
        CreateMap<AddDrivesDTO, Drives>();
        CreateMap<UpdateDrivesDTO, Drives>();

        CreateMap<GamingBuilds, GamingBuildsDTO>();
        CreateMap<AddGamingBuildsDTO, GamingBuilds>();
        CreateMap<UpdateGamingBuildsDTO, GamingBuilds>();

        CreateMap<Headphones, HeadphonesDTO>();
        CreateMap<AddHeadphonesDTO, Headphones>();
        CreateMap<UpdateHeadphonesDTO, Headphones>();

        CreateMap<MousePads, MousePadsDTO>().ReverseMap();
        CreateMap<MousePads, AddMousePadsDTO>().ReverseMap();
        CreateMap<UpdateMousePadsDTO, MousePads>();

        CreateMap<PowerSupplies, PowerSuppliesDTO>().ReverseMap();
        CreateMap<PowerSupplies, AddPowerSuppliesDTO>().ReverseMap();
        CreateMap<UpdatePowerSuppliesDTO, PowerSupplies>();

        CreateMap<RAM, RAMDTO>().ReverseMap();
        CreateMap<RAM, AddRAMDTO>().ReverseMap();
        CreateMap<UpdateRAMDTO, RAM>();
        
        CreateMap<TablesForGamers, TablesForGamersDTO>().ReverseMap();
        CreateMap<TablesForGamers, AddTablesForGamersDTO>().ReverseMap();
        CreateMap<UpdateTablesForGamersDTO, TablesForGamers>();
        
        CreateMap<Accessories, AccessoriesDto>().ReverseMap();
        CreateMap<Accessories, AddAccessoriesDto>().ReverseMap();
        CreateMap<UpdateAccessoriesDto, Accessories>();
        
    }
}
