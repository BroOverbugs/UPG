using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Mice : BaseEntity
{
    [Required]
    public string Sensor_type { get; set; } = string.Empty;
    [Required]
    public string Maximum_resolution_DPI_or_CPI { get; set; } = string.Empty;
    [Required]
    public int Number_of_buttons { get; set; }
    [Required]
    public string Polling_rate { get; set; } = string.Empty;
    [Required]
    public string Acceleration_max_acceleration { get; set; } = string.Empty;
    [Required]
    public string Prism { get; set; } = string.Empty;
    [Required]
    public string Internal_memory { get; set; } = string.Empty;
    [Required]
    public string Operating_mode { get; set; } = string.Empty;
    [Required]
    public string Wire_type { get; set; } = string.Empty;
    [Required]
    public string Wire_length { get; set; } = string.Empty;
    [Required]
    public string Weight_with_cable { get; set; } = string.Empty;
    public string Weight_without_cable { get; set; } = string.Empty;
    [Required]
    public string Dimensions { get; set; } = string.Empty;

}
