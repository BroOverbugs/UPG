using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Drives : BaseEntity
{
    [Required]
    public string Interface {  get; set; } = string.Empty;
    [Required]
    public string Reading_speed { get; set; } = string.Empty;
    [Required]
    public string Write_type { get; set; } = string.Empty;
    [Required]
    public string Drive_type { get; set;} = string.Empty;
    [Required]
    public string Volume { get; set; } = string.Empty;
}
