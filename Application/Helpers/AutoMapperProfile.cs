using AutoMapper;
using Domain.Entities;
using DTOS.Mouse_pads;
using DTOS.Power_supplies;
using DTOS.RAM;
using DTOS.Tables_for_gamers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
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
    }
}
