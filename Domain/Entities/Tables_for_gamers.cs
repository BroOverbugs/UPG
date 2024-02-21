using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Tables_for_gamers : BaseEntity
{
    [Required]
    public string I_or_O_panel { get; set; } = string.Empty;
    [Required]
    public string Table_adjustment { get; set; } = string.Empty;
    [Required]
    public string Max_load_up { get; set; } = string.Empty;
    [Required]
    public string Backlight { get; set; } = string.Empty;
    [Required]
    public string Dimensions { get; set; } = string.Empty;
    [Required]
    public string Weight { get; set; } = string.Empty;
}
