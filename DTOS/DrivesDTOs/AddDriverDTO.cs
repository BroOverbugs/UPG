using System.ComponentModel.DataAnnotations;

namespace DTOS.DrivesDTOs;

public class AddDriverDTO
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Interface { get; set; } = string.Empty;
    public string Reading_speed { get; set; } = string.Empty;
    public string Write_type { get; set; } = string.Empty;
    public string Drive_type { get; set; } = string.Empty;
    public string Volume { get; set; } = string.Empty;
}
