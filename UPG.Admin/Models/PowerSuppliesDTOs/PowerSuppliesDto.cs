namespace UPG.Admin.Models.PowerSuppliesDTOs;

public class PowerSuppliesDto
{
    public int Id { get; set; }
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
