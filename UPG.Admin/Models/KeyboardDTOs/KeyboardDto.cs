using System.ComponentModel.DataAnnotations;

namespace UPG.Admin.Models.KeyboardDTOs;

public class KeyboardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Keyboard_type { get; set; } = string.Empty;
    public string Switch_type { get; set; } = string.Empty;
    public string Interface { get; set; } = string.Empty;
    public string Backlight { get; set; } = string.Empty;
    public string Internal_memory { get; set; } = string.Empty;
    public bool Palm_rest { get; set; }
    public bool Cable_laying { get; set; }
    public int Number_of_keys { get; set; }
    public string Dimensions { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();
}
