namespace UPG.Admin.Models.MiceDTOs;

public class MiceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Sensor_type { get; set; } = string.Empty;
    public string Maximum_resolution_DPI_or_CPI { get; set; } = string.Empty;
    public int Number_of_buttons { get; set; }
    public string Polling_rate { get; set; } = string.Empty;
    public string Acceleration_max_acceleration { get; set; } = string.Empty;
    public bool Backlight { get; set; }
    public bool Internal_memory { get; set; }
    public string Operating_mode { get; set; } = string.Empty;
    public string Wire_type { get; set; } = string.Empty;
    public string Wire_length { get; set; } = string.Empty;
    public string Weight_with_cable { get; set; } = string.Empty;
    public string Weight_without_cable { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();
}