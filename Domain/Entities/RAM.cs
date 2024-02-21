using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class RAM : BaseEntity
{
    [Required]
    public string Capacity { get; set; } = string.Empty;
    [Required]
    public string Technologies { get; set; } = string.Empty;
    [Required]
    public string Timings { get; set; } = string.Empty;
    [Required]
    public string Memory_frequency { get; set; } = string.Empty;
    [Required]
    public string Backlight { get; set; } = string.Empty;

}
