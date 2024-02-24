using System.ComponentModel.DataAnnotations;

namespace DTOS.HeadphonesDTOs;

public class AddHeadphonesDTO
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Headphone_type { get; set; } = string.Empty;
    public string Operating_mode { get; set; } = string.Empty;
    public string Sound_type { get; set; } = string.Empty;
    public string Headphone_frequency_range { get; set; } = string.Empty;
    public string Headphone_impedance { get; set; } = string.Empty;
    public string Headphone_sensitivity { get; set; } = string.Empty;
    public string Microphone_frequency_range { get; set; } = string.Empty;
    public string Connection_or_connectors { get; set; } = string.Empty;
    public string Sound_card { get; set; } = string.Empty;

    public string Wire_length { get; set; } = string.Empty;
    public string Backlight { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
}
