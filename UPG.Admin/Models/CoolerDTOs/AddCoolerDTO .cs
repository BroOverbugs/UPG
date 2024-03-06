namespace UPG.Admin.Models.CoolerDTOs;

public class AddCoolerDTO
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public List<string> ImageUrls { get; set; } = new();
    public string Type { get; set; } = string.Empty;
    public string Socket { get; set; } = string.Empty;
    public string Power_dissipation { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public string Dimensions_of_complete_fans { get; set; } = string.Empty;
    public string Bearing_type { get; set; } = string.Empty;
    public string Rotational_speed { get; set; } = string.Empty;
}
