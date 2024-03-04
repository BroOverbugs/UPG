using Domain.Entities;
using DTOS.Tables_for_gamers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.RAM;

public class RAMDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Capacity { get; set; } = string.Empty;
    public string Technologies { get; set; } = string.Empty;
    public string Timings { get; set; } = string.Empty;
    public string Memory_frequency { get; set; } = string.Empty;
    public bool Backlight { get; set; }
    public List<string> ImageUrls { get; set; } = new();

    public static implicit operator RAMDTO(Domain.Entities.RAM ram)
    => new()
    {
        ID = ram.Id,
        Name = ram.Name,
        Price = ram.Price,
        Description = ram.Description,
        BrandName = ram.BrandName,
        Backlight = ram.Backlight,
        Capacity = ram.Capacity,
        Memory_frequency = ram.Memory_frequency,
        Technologies = ram.Technologies,
        Timings = ram.Timings,
        ImageUrls = ram.ImageUrls
    };
}
