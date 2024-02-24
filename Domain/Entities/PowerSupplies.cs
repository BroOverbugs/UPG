using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class PowerSupplies : BaseEntity
{
    [Required]
    public string Form_factor { get; set;} = string.Empty;
    [Required]
    public string Power { get; set; } = string.Empty;
    [Required]
    public string Security_technologies { get; set; } = string.Empty;
    [Required]
    public string Dimensions { get; set; } = string.Empty;
    [Required]
    public string Certificate { get; set; } = string.Empty;

}
