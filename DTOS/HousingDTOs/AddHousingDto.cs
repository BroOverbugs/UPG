using Domain.Entities;

namespace DTOS.HousingDTOs
{
    public class AddHousingDto
    {
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

        public static implicit operator Housing(AddHousingDto housing)
        => new()
        {
            Name = housing.Name,
            Price = housing.Price,
            Description = housing.Description,
            BrandName = housing.BrandName,
            Motherboard_form_factor = housing.Motherboard_form_factor,
            Size = housing.Size,
            Maximum_cooler_height = housing.Maximum_cooler_height,
            Maximum_video_card_length = housing.Maximum_video_card_length,
            Dimensions = housing.Dimensions,
            Built_in_fans = housing.Built_in_fans,
            Spaces_for_additional_coolers = housing.Spaces_for_additional_coolers,
            Possibility_of_installing_liquid_cooling = housing.Possibility_of_installing_liquid_cooling,
            Connectors_on_the_front_panel = housing.Connectors_on_the_front_panel,
            Case_color = housing.Case_color,
            ImageUrls = housing.ImageUrls
        };
    }
}
