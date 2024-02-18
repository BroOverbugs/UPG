using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Mouse_pads : BaseEntity
{
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public string Material { get; set; } = string.Empty;
    [Required]
    public string Dimensions { get; set; } = string.Empty;

}
