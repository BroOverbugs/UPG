using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class GamingBuilds : BaseEntity
{
    [Required]
    public string MotherBoard {  get; set; } = string.Empty;
    [Required]
    public string CPU {  get; set; } = string.Empty;
    [Required]
    public string Cooler {  get; set; } = string.Empty;
    [Required]
    public string RAM {  get; set; } = string.Empty;
    public string SSD { get; set; } = string.Empty;
    public string HDD {  get; set; } = string.Empty;
    [Required]
    public string GPU {  get; set; } = string.Empty;
    [Required]
    public string PSU {  get; set; } = string.Empty;
    [Required]
    public string Case { get; set; } = string.Empty;
}
