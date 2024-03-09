namespace UPG.Admin.Models.TablesForgamersDTOs;
public class TablesForGamersDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string I_or_O_panel { get; set; } = string.Empty;
    public string Table_adjustment { get; set; } = string.Empty;
    public string Max_load_up { get; set; } = string.Empty;
    public bool Backlight { get; set; }
    public string Dimensions { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();
}
