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
        CreateMap<Mouse_pads, Mouse_padsDTO>().ReverseMap();
        CreateMap<Mouse_pads, AddMouse_padsDTO>().ReverseMap();
        CreateMap<UpdateMouse_padsDTO, Mouse_pads>();

        CreateMap<Power_supplies, Power_suppliesDTO>().ReverseMap();
        CreateMap<Power_supplies, AddPower_suppliesDTO>().ReverseMap();
        CreateMap<UpdatePower_suppliesDTO, Power_supplies>();

        CreateMap<RAM, RAMDTO>().ReverseMap();
        CreateMap<RAM, AddRAMDTO>().ReverseMap();
        CreateMap<UpdateRAMDTO, RAM>();

        CreateMap<Tables_for_gamers, Tables_for_gamersDTO>().ReverseMap();
        CreateMap<Tables_for_gamers, AddTables_for_gamersDTO>().ReverseMap();
        CreateMap<UpdateTables_for_gamersDTO, Tables_for_gamers>();
    }
}
