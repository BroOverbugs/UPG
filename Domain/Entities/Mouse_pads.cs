using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Mouse_pads : BaseEntity
{
    [Required]
    public string Material { get; set; } = string.Empty;
    [Required]
    public string Dimensions { get; set; } = string.Empty;

}
