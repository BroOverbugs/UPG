using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Cooler : BaseEntity
{
    [Required]
    public string Type { get; set; } = string .Empty;
    [Required]
    public string Socket { get; set; } = string.Empty;
    [Required]
    public string Power_dissipation { get; set; } = string.Empty;
    [Required]
    public string Dimensions {  get; set; } = string.Empty;
    [Required]
    public string Dimensions_of_complete_fans {  get; set; } = string.Empty;
    [Required]
    public string Bearing_type {  get; set; } = string.Empty;
    [Required]
    public string Rotational_speed {  get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
}
