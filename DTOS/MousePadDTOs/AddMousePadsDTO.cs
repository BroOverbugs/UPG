namespace DTOS.MousePadDTOs;

public class AddMousePadsDTO
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Material { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();
}
