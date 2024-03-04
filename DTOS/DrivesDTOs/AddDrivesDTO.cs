using System.ComponentModel.DataAnnotations;

namespace DTOS.DrivesDTOs;

public class AddDrivesDTO
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public List<string> ImageUrls { get; set; } = new();
    public string Interface { get; set; } = string.Empty;
    public string Reading_speed { get; set; } = string.Empty;
    public string Write_type { get; set; } = string.Empty;
    public string Drive_type { get; set; } = string.Empty;
    public string Volume { get; set; } = string.Empty;
}
