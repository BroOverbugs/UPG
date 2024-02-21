using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class RAM : BaseEntity
{
    [Required]
    public string Capacity { get; set; } = string.Empty;
    [Required]
    public string Technologies { get; set; } = string.Empty;
    [Required]
    public string Timings { get; set; } = string.Empty;
    [Required]
    public string Memory_frequency { get; set; } = string.Empty;
    [Required]
    public string Backlight { get; set; } = string.Empty;

}
