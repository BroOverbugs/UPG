using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Power_supplies : BaseEntity
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
