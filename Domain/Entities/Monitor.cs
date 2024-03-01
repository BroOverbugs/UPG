using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Monitor : BaseEntity
{
    [Required]
    public string Diagonal {  get; set; } = string.Empty;
    [Required]
    public string Screen_type { get; set; } = string.Empty;
    [Required]
    public string Matrix_type { get; set; } = string.Empty;
    [Required]
    public string Resolution_FHD { get; set; } = string.Empty;
    [Required]
    public string Aspect_ratio { get; set; } = string.Empty;
    [Required]
    public string Frame_rate { get; set; } = string.Empty;
    [Required]
    public string Response_time { get; set; } = string.Empty;
    [Required]
    public string Viewing_angle { get; set; } = string.Empty;
    [Required]
    public string Interface { get; set; } = string.Empty;
    [Required]
    public string VESA_Mount { get; set; } = string.Empty;
    [Required]
    public string Technologies { get; set; } = string.Empty;
    [Required]
    public string Adjustment { get; set; } = string.Empty;
    public bool HDR { get; set; }
    public bool Guarantee_period { get; set; }
}