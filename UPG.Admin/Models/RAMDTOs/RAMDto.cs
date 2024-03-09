namespace UPG.Admin.Models.RAMDTOs;

public class RAMDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Capacity { get; set; } = string.Empty;
    public string Technologies { get; set; } = string.Empty;
    public string Timings { get; set; } = string.Empty;
    public string Memory_frequency { get; set; } = string.Empty;
    public bool Backlight { get; set; }
    public List<string> ImageUrls { get; set; } = new();
}
