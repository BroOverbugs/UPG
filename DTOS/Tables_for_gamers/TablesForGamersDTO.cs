using Domain.Entities;
using DTOS.Mouse_pads;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Tables_for_gamers;

public class TablesForGamersDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string I_or_O_panel { get; set; } = string.Empty;
    public string Table_adjustment { get; set; } = string.Empty;
    public string Max_load_up { get; set; } = string.Empty;
    public bool Backlight { get; set; }
    public string Dimensions { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();

    public static implicit operator TablesForGamersDTO(TablesForGamers TablesForGamers)
        => new()
        {
            ID = TablesForGamers.Id,
            Name = TablesForGamers.Name,
            Price = TablesForGamers.Price,
            Description = TablesForGamers.Description,
            BrandName = TablesForGamers.BrandName,
            Dimensions = TablesForGamers.Dimensions,
            Table_adjustment = TablesForGamers.Table_adjustment,
            Backlight = TablesForGamers.Backlight,
            I_or_O_panel = TablesForGamers.I_or_O_panel,
            Max_load_up = TablesForGamers.Max_load_up,
            Weight = TablesForGamers.Weight,
            ImageUrls = TablesForGamers.ImageUrls
        };
}
