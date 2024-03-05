using System.ComponentModel.DataAnnotations;

namespace DTOS.GamingBuildsDTOs;

public class AddGamingBuildsDTO
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public List<string> ImageUrls { get; set; } = new();
    public string MotherBoard { get; set; } = string.Empty;
    public string CPU { get; set; } = string.Empty;
    public string Cooler { get; set; } = string.Empty;
    public string RAM { get; set; } = string.Empty;
    public string SSD { get; set; } = string.Empty;
    public string HDD { get; set; } = string.Empty;
    public string GPU { get; set; } = string.Empty;
    public string PSU { get; set; } = string.Empty;
    public string Case { get; set; } = string.Empty;
}
