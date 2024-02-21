using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Gaming_builds : BaseEntity
{
    [Required]
    public string Mother_board {  get; set; } = string.Empty;
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
