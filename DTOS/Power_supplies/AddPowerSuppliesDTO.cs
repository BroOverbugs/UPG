﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Power_supplies;

public class AddPowerSuppliesDTO
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Form_factor { get; set; } = string.Empty;
    public string Power { get; set; } = string.Empty;
    public string Security_technologies { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public string Certificate { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();
}
