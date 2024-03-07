namespace UPG.Admin.Models.HousingDTOs;

public class HousingDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Motherboard_form_factor { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string Maximum_cooler_height { get; set; } = string.Empty;
    public string Maximum_video_card_length { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public bool Built_in_fans { get; set; }
    public string Spaces_for_additional_coolers { get; set; } = string.Empty;
    public string Possibility_of_installing_liquid_cooling { get; set; } = string.Empty;
    public string Connectors_on_the_front_panel { get; set; } = string.Empty;
    public string Case_color { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();
}