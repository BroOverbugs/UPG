using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;

public class Housing : BaseEntity
{
    [Required] 
    public string Motherboard_form_factor { get; set; } = string.Empty;
    [Required] 
    public string Size { get; set; } = string.Empty;
    [Required]
    public string Maximum_cooler_height { get; set; } = string.Empty;
    [Required]
    public string Maximum_video_card_length { get; set; } = string.Empty; 
    [Required]
    public string Dimensions { get; set; } = string.Empty;
    [Required]
    public string Built_in_fans { get; set; } = string.Empty;
    [Required]
    public string Spaces_for_additional_coolers { get; set; } = string.Empty;
    [Required]
    public string Possibility_of_installing_liquid_cooling { get; set; } = string.Empty;
    [Required]
    public string Connectors_on_the_front_panel { get; set; } = string.Empty; 
    [Required]
    public string Case_color { get; set; } = string.Empty;

}
