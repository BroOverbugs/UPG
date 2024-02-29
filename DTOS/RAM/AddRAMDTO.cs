using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.RAM;

public class AddRAMDTO
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Capacity { get; set; } = string.Empty;
    public string Technologies { get; set; } = string.Empty;
    public string Timings { get; set; } = string.Empty;
    public string Memory_frequency { get; set; } = string.Empty;
    public string Backlight { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();
}
