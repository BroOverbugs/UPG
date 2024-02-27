using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class MousePads : BaseEntity
{
    [Required]
    public string Material { get; set; } = string.Empty;
    [Required]
    public string Dimensions { get; set; } = string.Empty;
}
