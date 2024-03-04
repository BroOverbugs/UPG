using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class TablesForGamers : BaseEntity
{
    [Required]
    public string I_or_O_panel { get; set; } = string.Empty;
    [Required]
    public string Table_adjustment { get; set; } = string.Empty;
    [Required]
    public string Max_load_up { get; set; } = string.Empty;
    [Required]
    public bool Backlight { get; set; }
    [Required]
    public string Dimensions { get; set; } = string.Empty;
    [Required]
    public string Weight { get; set; } = string.Empty;
}
