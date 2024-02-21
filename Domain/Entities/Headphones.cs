using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Headphones : BaseEntity
{
    [Required]
    public string Headphone_type { get; set; } = string.Empty;
    [Required]
    public string Operating_mode { get; set; } = string.Empty;
    [Required]
    public string Sound_type { get; set; } = string.Empty;
    [Required]
    public string Headphone_frequency_range { get; set; } = string.Empty;
    [Required] 
    public string Headphone_impedance { get; set; } = string.Empty;
    [Required] 
    public string Headphone_sensitivity { get; set; } = string.Empty;
    [Required] 
    public string Microphone_frequency_range { get; set; } = string.Empty;
    public string Connection_or_connectors { get; set; } = string.Empty;
    [Required] 
    public string Sound_card { get; set; } = string.Empty;
     
    public string Wire_length { get; set; } = string.Empty;
    [Required] 
    public string Backlight { get; set; } = string.Empty;
    [Required]
    public string Weight { get; set; } = string.Empty;
}
