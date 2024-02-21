using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Armchairs : BaseEntity
{
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public string Upholstery_material { get; set; } =string.Empty; //koja yoki boshqa narsalar
    [Required]
    public string Color_material { get; set; } = string.Empty;
    [Required]
    public string Armrests { get; set; } = string.Empty; // 4d,3d
    public string Cross_material {  get; set; } = string.Empty;
    [Required]
    public string Reclining { get; set; } = string.Empty;
    public string Rocking_mechanism {  get; set; } = string.Empty;
    public string Permissible_load {  get; set; } = string.Empty;//(kg)
    public string Frame_material { get; set; } = string.Empty;
}
