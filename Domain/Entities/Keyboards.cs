using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Keyboards : BaseEntity
{
    [Required]
    public string Keyboard_type { get; set; } = string.Empty;
    [Required]
    public string Switch_type { get; set; } = string.Empty;
    [Required]
    public string Interface { get; set; } = string.Empty;
    [Required]
    public string Backlight { get; set; } = string.Empty;
    [Required]
    public string Internal_memory { get; set; } = string.Empty;
    [Required]
    public string Palm_rest { get; set; } = string.Empty;
    [Required]
    public string Cable_laying { get; set; } = string.Empty;
    [Required]
    public int Number_of_keys { get; set; }
    [Required]
    public string Dimensions { get; set; } = string.Empty;
    [Required]
    public string Weight { get; set; } = string.Empty;
    [Required]
    public string Description {  get; set; } = string.Empty;

}
