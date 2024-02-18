using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Monitors : BaseEntity
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
    public string HDR { get; set; } = string.Empty;
    public string Guarantee_period { get; set; } = string.Empty;
    [Required]
    public string Description {  get; set; } = string.Empty;

}
